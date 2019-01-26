// Copyright (c) ProjectName. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

using System.Threading.Tasks;

using ProjectName.Domain.Users.Entities;

namespace ProjectName.Domain.Users.Queries
{
    public class UserByLoginAndPasswordQuery : BaseQuery
    {
        public UserByLoginAndPasswordQuery(IAppUnitOfWork uow)
            : base(uow)
        {
        }

        public async Task<User> Execute(string login, string password) =>
            await Uow.UserRepository.GetByLoginAndPassword(login, Shared.Utils.HashString(password))
            ?? throw new Shared.Exceptions.NotFoundException();
    }
}
