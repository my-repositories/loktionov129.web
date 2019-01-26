// Copyright (c) ProjectName. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

using System.Linq;

using ProjectName.DataAccess.Core;
using ProjectName.DataAccess.Repositories;
using ProjectName.Domain;
using ProjectName.Domain.Users.Entities;
using ProjectName.Domain.Users.Repositories;

namespace ProjectName.DataAccess
{
    public class AppUnitOfWork : EfUnitOfWork<AppDbContext>, IAppUnitOfWork
    {
        private IUserRepository userRepository;

        public AppUnitOfWork(AppDbContext context)
            : base(context)
        {
        }

        public IQueryable<User> Users => Context.Users;

        public IUserRepository UserRepository
        {
            get
            {
                if (userRepository == null)
                {
                    userRepository = new UserRepository(Context);
                }

                return userRepository;
            }
        }
    }
}
