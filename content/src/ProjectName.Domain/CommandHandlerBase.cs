﻿// Copyright (c) ProjectName. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

namespace ProjectName.Domain
{
    public abstract class CommandHandlerBase<TCommand>
        : Abstract.ICommandHandler<TCommand>
        where TCommand : Abstract.ICommand
    {
        protected CommandHandlerBase(IAppUnitOfWork uow)
        {
            Uow = uow;
        }

        protected IAppUnitOfWork Uow { get; }

        public abstract System.Threading.Tasks.Task<int> Execute(TCommand command);

        public void Dispose() => Uow.Dispose();
    }
}
