// Copyright (c) ProjectName. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

using System.ComponentModel.DataAnnotations;

using ProjectName.Abstract;
using ProjectName.Domain.Users.Entities;

namespace ProjectName.Domain.Users.Commands
{
    public class UpdatePasswordCommand : ICommand
    {
        public int Id { get; set; }

        [Required(ErrorMessage = User.Errors.PasswordRequired)]
        [MinLength(8, ErrorMessage = User.Errors.PasswordMinLength)]
        [MaxLength(249, ErrorMessage = User.Errors.PasswordMaxLength)]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = User.Errors.PasswordRequired)]
        [MinLength(8, ErrorMessage = User.Errors.PasswordMinLength)]
        [MaxLength(249, ErrorMessage = User.Errors.PasswordMaxLength)]
        public string Password { get; set; }

        [System.ComponentModel.Description("Repeat the password.")]
        [Required(ErrorMessage = User.Errors.PasswordRepeatRequired)]
        [Compare("Password", ErrorMessage = User.Errors.PasswordRepeatMatch)]
        public string PasswordRepeat { get; set; }
    }
}
