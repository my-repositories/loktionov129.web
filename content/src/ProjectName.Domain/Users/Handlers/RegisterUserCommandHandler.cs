// Copyright (c) ProjectName. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

using System.Threading.Tasks;

using ProjectName.Domain.Users.Commands;
using ProjectName.Domain.Users.Entities;
using ProjectName.Domain.Users.Enums;
using ProjectName.Shared.Exceptions;

namespace ProjectName.Domain.Users.Handlers
{
    public class RegisterUserCommandHandler
        : CommandHandlerBase<RegisterUserCommand>
    {
        public RegisterUserCommandHandler(IAppUnitOfWork uow)
            : base(uow)
        {
        }

        public override async Task<int> Execute(RegisterUserCommand command)
        {
            var foundUser = await Uow.UserRepository.GetByLogin(command.Login);
            if (foundUser != null)
            {
                throw new ConflictException();
            }

            var user = AutoMapper.Mapper.Map<RegisterUserCommand, User>(command);
            user.Password = Shared.Utils.HashString(command.Password);
            user.Nickname = command.Nickname = command.Nickname ?? command.Login;
            user.Role = Role.User;

            await Uow.UserRepository.Add(user);
            return await Uow.SaveChanges();
        }
    }
}
