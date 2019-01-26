// Copyright (c) ProjectName. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

using System;
using ProjectName.Web.Sockets.Abstract;

namespace ProjectName.Web.Sockets.Core
{
    public class HandlerFactory
    {
        private readonly IServiceProvider serviceProvider;

        public HandlerFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public IMessageHandler CreateHandler(string messageName)
        {
            var type = Type.GetType($"ProjectName.Web.Sockets.Handlers.{messageName}Handler", true, true);
            return serviceProvider.GetService(type) as IMessageHandler
                   ?? throw new TypeLoadException();
        }
    }
}
