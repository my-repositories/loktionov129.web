// Copyright (c) ProjectName. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;

using ProjectName.Domain.Users.Dtos;

namespace ProjectName.Web.Sockets.Messages.Server
{
    public class AuthMessage : Abstract.IMessage
    {
        public ICollection<UserDto> UsersList { get; set; }
    }
}
