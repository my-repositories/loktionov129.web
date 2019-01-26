// Copyright (c) ProjectName. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

using ProjectName.Abstract;

namespace ProjectName.Domain
{
    public abstract class BaseQuery : IQuery
    {
        protected BaseQuery(IAppUnitOfWork uow) => Uow = uow;

        protected IAppUnitOfWork Uow { get; }
    }
}
