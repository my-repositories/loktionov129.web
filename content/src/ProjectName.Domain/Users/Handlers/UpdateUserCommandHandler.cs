// Copyright (c) ProjectName. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

using System.Threading.Tasks;
using ProjectName.Domain.Users.Commands;
using ProjectName.Shared.Exceptions;

namespace ProjectName.Domain.Users.Handlers
{
    public class UpdateUserCommandHandler
        : CommandHandlerBase<UpdateUserCommand>
    {
        public UpdateUserCommandHandler(IAppUnitOfWork uow)
            : base(uow)
        {
        }

        public override async Task<int> Execute(UpdateUserCommand command)
        {
            var foundUser = await Uow.UserRepository.GetById(command.Id)
                               ?? throw new NotFoundException();

            foundUser.Nickname = command.Nickname;

            return await Uow.SaveChanges();
        }
    }
}
