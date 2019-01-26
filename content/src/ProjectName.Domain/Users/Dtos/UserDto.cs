// Copyright (c) ProjectName. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

using System;
using ProjectName.Domain.Users.Enums;

namespace ProjectName.Domain.Users.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }

        public string Nickname { get; set; }

        public Role Role { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.Now;
    }
}
