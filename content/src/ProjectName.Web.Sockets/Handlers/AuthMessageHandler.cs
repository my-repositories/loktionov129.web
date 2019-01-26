// Copyright (c) ProjectName. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using ProjectName.Abstract;
using ProjectName.Domain.Users.Dtos;
using ProjectName.Domain.Users.Entities;
using ProjectName.Domain.Users.Queries;
using ProjectName.Shared;
using ProjectName.Shared.Exceptions;
using ProjectName.Web.Sockets.Core;
using ProjectName.Web.Sockets.Messages;

namespace ProjectName.Web.Sockets.Handlers
{
    public class AuthMessageHandler : MessageHandler<Messages.Client.AuthMessage>
    {
        private readonly ILogger<AuthMessageHandler> logger;

        private readonly IQueryFactory queryFactory;

        public AuthMessageHandler(ILogger<AuthMessageHandler> logger, IQueryFactory queryFactory)
        {
            this.logger = logger;
            this.queryFactory = queryFactory;
        }

        public override Task CheckAuth()
        {
            return Task.CompletedTask;
        }

        public override async Task Handle()
        {
            try
            {
                var user = await GetUserByToken(Context.Message.Payload.AuthToken);
                var response = new Messages.Server.AuthMessage()
                {
                    UsersList = Context.ConnectionManager.GetOnlineUsers()
                };
                Context.ConnectionManager.AddSocket(user, Context.Socket);
                await Context.ConnectionManager.SendMessageAsync(Context.Socket, response);

                var connectionMessage = new Messages.Server.UserConnectionMessage()
                {
                    User = user,
                    Status = ConnectionStatus.Connect
                };
                await Context.ConnectionManager.SendMessageToAllExcludeOneAsync(Context.Socket, connectionMessage);
            }
            catch (Exception ex)
            {
                logger.LogCritical(ex, "Unhandled exception in AuthMessageHandler in method 'Handle'.");
            }
        }

        private async Task<UserDto> GetUserByToken(string token)
        {
            try
            {
                var userId = Utils.GetUserIdFromJwt(token);
                if (Context.ConnectionManager.IsConnected(userId))
                {
                    throw new ConflictException("ALREADY_CONNECTED");
                }

                var user = await queryFactory.ResolveQuery<UserByIdQuery>().Execute(userId);

                return AutoMapper.Mapper.Map<User, UserDto>(user);
            }
            catch (NotFoundException ex)
            {
                await Disconnect(404, ex.Message);
                throw;
            }
            catch (ConflictException ex)
            {
                await Disconnect(409, ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                logger.LogCritical(ex, "Unhandled exception in AuthMessageHandler in method 'GetUserByToken'.");
                throw;
            }
        }
    }
}
