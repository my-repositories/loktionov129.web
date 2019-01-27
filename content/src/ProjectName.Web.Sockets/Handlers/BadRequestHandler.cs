﻿// Copyright (c) ProjectName. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

using System.Net.WebSockets;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;
using ProjectName.Web.Sockets.Abstract;
using ProjectName.Web.Sockets.Core;

namespace ProjectName.Web.Sockets.Handlers
{
    public class BadRequestHandler : MessageHandler<Message>
    {
        private readonly ILogger<BadRequestHandler> logger;

        public BadRequestHandler(ILogger<BadRequestHandler> logger)
        {
            this.logger = logger;
        }

        public override IMessageHandler Initialize(string json, WebSocket socket, ConnectionManager connectionManager)
        {
            Context = new HandlerContext<Message>(null, socket, connectionManager);
            return this;
        }

        public override async Task Handle()
        {
            logger.LogError("Receive bad message.");
            await Disconnect(400, "Bad request");
        }
    }
}
