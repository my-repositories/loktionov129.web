// Copyright (c) ProjectName. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

using System.Threading.Tasks;
using ProjectName.Domain.Users.Entities;

namespace ProjectName.Domain.Users.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetById(int id);

        Task<User> GetByLogin(string login);

        Task<User> GetByLoginAndPassword(string login, string password);
    }
}
