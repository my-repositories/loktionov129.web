// Copyright (c) ProjectName. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using ProjectName.Web.Sockets.Core;

namespace ProjectName.Web.Api.WebSockets
{
    public static class WebSocketExtensions
    {
        public static IApplicationBuilder MapWebSocketManager(
            this IApplicationBuilder app,
            PathString path,
            WebSocketRouter webSocketRouter)
        {
            return app.Map(path,  x => x.UseMiddleware<WebSocketManagerMiddleware>(webSocketRouter));
        }

        public static void AddWebSocketManager(this IServiceCollection services)
        {
            DiConfig.ConfigureServices(services);
        }
    }
}
