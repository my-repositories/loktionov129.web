// Copyright (c) ProjectName. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

using System;
using System.Linq;

using Microsoft.Extensions.DependencyInjection;
using ProjectName.Abstract;

namespace ProjectName.Infrastructure
{
    public class CommandFactory : ICommandFactory
    {
        private readonly IServiceProvider serviceProvider;

        public CommandFactory(IServiceProvider serviceProvider) => this.serviceProvider = serviceProvider;

        public async System.Threading.Tasks.Task Execute<T>(T command)
            where T : class, ICommand
        {
            var commandHandlers = serviceProvider.GetServices<ICommandHandler<T>>().ToArray();
            if ((commandHandlers == null) || !commandHandlers.Any())
            {
                throw new ArgumentException("Unknown command \"" + typeof(T).FullName + "\"");
            }

            foreach (var commandHandler in commandHandlers)
            {
                await commandHandler.Execute(command);
                commandHandler.Dispose();
            }
        }
    }
}
