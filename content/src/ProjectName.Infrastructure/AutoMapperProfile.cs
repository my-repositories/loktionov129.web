// Copyright (c) ProjectName. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

using ProjectName.Domain.Users.Commands;
using ProjectName.Domain.Users.Dtos;
using ProjectName.Domain.Users.Entities;

namespace ProjectName.Infrastructure
{
    public class AutoMapperProfile : AutoMapper.Profile
    {
        public AutoMapperProfile()
        {
            ConfigureUser();
        }

        private void ConfigureUser()
        {
            CreateMap<User, UserDto>();
            CreateMap<AuthorizeUserCommand, User>();
            CreateMap<RegisterUserCommand, User>();
        }
    }
}
