// Copyright (c) ProjectName. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

using System.Linq;

using ProjectName.Abstract;
using ProjectName.Domain.Users.Entities;
using ProjectName.Domain.Users.Repositories;

namespace ProjectName.Domain
{
    public interface IAppUnitOfWork : IUnitOfWork
    {
        IQueryable<User> Users { get; }

        IUserRepository UserRepository { get; }
    }
}
