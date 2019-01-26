// Copyright (c) ProjectName. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

using System.Net.WebSockets;

using ProjectName.Domain.Users.Dtos;
using ProjectName.Web.Sockets.Abstract;
using ProjectName.Web.Sockets.Messages;

namespace ProjectName.Web.Sockets.Core
{
    public class HandlerContext<T>
        where T : IMessage
    {
        public HandlerContext(ClientMessage<T> message, WebSocket socket, ConnectionManager connectionManager)
        {
            Message = message;
            Socket = socket;
            ConnectionManager = connectionManager;
        }

        public ClientMessage<T> Message { get;  }

        public WebSocket Socket { get; }

        public UserDto Sender => ConnectionManager.GetUser(Socket);

        public ConnectionManager ConnectionManager { get; }
    }
}
