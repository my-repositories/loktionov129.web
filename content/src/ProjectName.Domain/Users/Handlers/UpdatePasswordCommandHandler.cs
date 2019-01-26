// Copyright (c) ProjectName. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

using System.Threading.Tasks;
using ProjectName.Domain.Users.Commands;
using ProjectName.Shared;
using ProjectName.Shared.Exceptions;

namespace ProjectName.Domain.Users.Handlers
{
    public class UpdatePasswordCommandHandler
        : CommandHandlerBase<UpdatePasswordCommand>
    {
        public UpdatePasswordCommandHandler(IAppUnitOfWork uow)
            : base(uow)
        {
        }

        public override async Task<int> Execute(UpdatePasswordCommand command)
        {
            var foundUser = await Uow.UserRepository.GetById(command.Id)
                               ?? throw new NotFoundException();

            if (foundUser.Password != Utils.HashString(command.OldPassword))
            {
                throw new ForbiddenException();
            }

            foundUser.Password = Utils.HashString(command.Password);
            return await Uow.SaveChanges();
        }
    }
}
