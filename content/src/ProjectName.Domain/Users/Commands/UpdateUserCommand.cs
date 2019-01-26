// Copyright (c) ProjectName. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

using System.ComponentModel.DataAnnotations;

using ProjectName.Abstract;
using ProjectName.Domain.Users.Entities;

namespace ProjectName.Domain.Users.Commands
{
    public class UpdateUserCommand : ICommand
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(249)]
        public string Avatar { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = User.Errors.NicknameMinLength)]
        [MaxLength(20, ErrorMessage = User.Errors.NicknameMaxLength)]
        [RegularExpression(@"^[^\s].{1,18}[^\s]$", ErrorMessage = User.Errors.NicknameRegex)]
        public string Nickname { get; set; }
    }
}
