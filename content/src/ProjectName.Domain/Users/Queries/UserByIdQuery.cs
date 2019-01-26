// Copyright (c) ProjectName. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

using System.Threading.Tasks;

using ProjectName.Domain.Users.Entities;

namespace ProjectName.Domain.Users.Queries
{
    public class UserByIdQuery : BaseQuery
    {
        public UserByIdQuery(IAppUnitOfWork uow)
            : base(uow)
        {
        }

        public async Task<User> Execute(int id) =>
            await Uow.UserRepository.GetById(id)
            ?? throw new Shared.Exceptions.NotFoundException();
    }
}
