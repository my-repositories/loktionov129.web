// Copyright (c) ProjectName. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using ProjectName.Abstract;
using ProjectName.Domain.Users.Commands;
using ProjectName.Domain.Users.Dtos;

namespace ProjectName.Web.Sockets.Core
{
    public class ConnectionManager
    {
        private readonly ICommandFactory commandFactory;
        private readonly ILogger<WebSocketRouter> logger;

        public ConnectionManager(ICommandFactory commandFactory, ILogger<WebSocketRouter> logger)
        {
            this.commandFactory = commandFactory;
            this.logger = logger;
            ConnectedSockets = new ConcurrentDictionary<UserDto, WebSocket>();
        }

        private ConcurrentDictionary<UserDto, WebSocket> ConnectedSockets { get; }

        public void AddSocket(UserDto user, WebSocket socket) => ConnectedSockets.TryAdd(user, socket);

        public UserDto GetUser(WebSocket socket) => ConnectedSockets.FirstOrDefault(x => x.Value == socket).Key;

        public ICollection<UserDto> GetOnlineUsers() => ConnectedSockets.Keys;

        public WebSocket FindSocket(int userId)
            => ConnectedSockets.FirstOrDefault(p => p.Key.Id == userId).Value;

        public bool IsConnected(int userId) => FindSocket(userId) != null;

        public bool IsConnected(WebSocket socket) => ConnectedSockets.Values.FirstOrDefault(x => x == socket) != null;

        public async Task RemoveSocketAsync(WebSocket socket)
        {
            var user = GetUser(socket);
            if (user != null)
            {
                await RemoveSocketAsync(user);
            }

            try
            {
                await socket.CloseOutputAsync(WebSocketCloseStatus.NormalClosure, null, CancellationToken.None);
            }
            catch (Exception)
            {
                // ignored
            }
        }

        public async Task SendMessageAsync(WebSocket socket, string message)
        {
            if (socket.State != WebSocketState.Open)
            {
                return;
            }

            try
            {
                await socket.SendAsync(
                    buffer: new ArraySegment<byte>(
                        array: Encoding.ASCII.GetBytes(message),
                        offset: 0,
                        count: message.Length),
                    messageType: WebSocketMessageType.Text,
                    endOfMessage: true,
                    cancellationToken: CancellationToken.None);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while sending the message: '{@message}'", message);
            }
        }

        public async Task SendMessageToAllAsync(string message)
        {
            foreach (var pair in ConnectedSockets)
            {
                await SendMessageAsync(pair.Value, message);
            }
        }

        public async Task SendMessageToAllExcludeOneAsync(WebSocket excludedSocket, string message)
        {
            var filteredSockets = ConnectedSockets.Where(client => client.Value != excludedSocket);

            foreach (var pair in filteredSockets)
            {
                await SendMessageAsync(pair.Value, message);
            }
        }

        private async Task RemoveSocketAsync(UserDto user)
        {
            try
            {
                ConnectedSockets.TryRemove(user, out var socket);

                var connectionMessage = new Messages.Server.UserConnectionMessage()
                {
                    User = user,
                    Status = Messages.ConnectionStatus.Disconnect
                };
                await this.SendMessageToAllExcludeOneAsync(socket, connectionMessage);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while removing the socket.");
            }
        }
    }
}
