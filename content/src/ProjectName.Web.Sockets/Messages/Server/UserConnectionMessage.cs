// Copyright (c) ProjectName. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

using ProjectName.Domain.Users.Dtos;

namespace ProjectName.Web.Sockets.Messages.Server
{
    public class UserConnectionMessage : Abstract.IMessage
    {
        public UserDto User { get; set; }

        public string Status { get; set; }
    }
}
