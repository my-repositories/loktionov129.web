// Copyright (c) ProjectName. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

namespace ProjectName.Domain.Users.Dtos
{
    public class AuthInfoDto
    {
        public AuthInfoDto(UserDto user, string authToken)
        {
            AuthToken = authToken;
            User = user;
        }

        public string AuthToken { get; set; }

        public UserDto User { get; set; }
    }
}
