// Copyright (c) ProjectName. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

using System.ComponentModel.DataAnnotations;

using ProjectName.Abstract;
using ProjectName.Domain.Users.Entities;

namespace ProjectName.Domain.Users.Commands
{
    public class RegisterUserCommand : ICommand
    {
        [Required(ErrorMessage = User.Errors.LoginRequired)]
        [MinLength(3, ErrorMessage = User.Errors.LoginMinLength)]
        [MaxLength(20, ErrorMessage = User.Errors.LoginMaxLength)]
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = User.Errors.LoginRegex)]
        public string Login { get; set; }

        [MinLength(3, ErrorMessage = User.Errors.NicknameMinLength)]
        [MaxLength(20, ErrorMessage = User.Errors.NicknameMaxLength)]
        [RegularExpression(@"^[^\s].{1,18}[^\s]$", ErrorMessage = User.Errors.NicknameRegex)]
        public string Nickname { get; set; }

        [Required(ErrorMessage = User.Errors.PasswordRequired)]
        [MinLength(8, ErrorMessage = User.Errors.PasswordMinLength)]
        [MaxLength(249, ErrorMessage = User.Errors.PasswordMaxLength)]
        public string Password { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        [System.ComponentModel.Description("Repeat the password.")]
        [Required(ErrorMessage = User.Errors.PasswordRepeatRequired)]
        [Compare("Password", ErrorMessage = User.Errors.PasswordRepeatMatch)]
        public string PasswordRepeat { get; set; }
    }
}
