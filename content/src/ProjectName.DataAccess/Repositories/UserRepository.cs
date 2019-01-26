// Copyright (c) ProjectName. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using ProjectName.DataAccess.Core;
using ProjectName.Domain.Users.Entities;
using ProjectName.Domain.Users.Repositories;

namespace ProjectName.DataAccess.Repositories
{
    public class UserRepository : EfRepository<User, AppDbContext>, IUserRepository
    {
        public UserRepository(AppDbContext context)
            : base(context)
        {
        }

        public async Task<User> GetById(int id) =>
            await Context.Users.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<User> GetByLogin(string login) =>
            await Context.Users.FirstOrDefaultAsync(x => x.Login == login);

        public async Task<User> GetByLoginAndPassword(string login, string password) =>
            await Context.Users.FirstOrDefaultAsync(x => x.Login == login && x.Password == password);
    }
}
