// Copyright (c) ProjectName. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectName.Abstract;
using ProjectName.Domain.Users.Commands;
using ProjectName.Domain.Users.Entities;
using ProjectName.Shared;
using ProjectName.Web.Api.Utils;

namespace ProjectName.Web.Api.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ManageController : ControllerBase
    {
        private readonly ICommandFactory commandFactory;

        public ManageController(ICommandFactory commandFactory)
        {
            this.commandFactory = commandFactory;
        }

        [Authorize]
        [HttpPatch]
        public async Task UpdateUser(UpdateUserCommand command)
        {
            ModelState.ThrowValidationExceptionIfInvalid<User.Errors>();

            command.Id = User.Claims.GetUserId();
            await commandFactory.Execute(command);
        }

        [Authorize]
        [HttpPatch("password")]
        public async Task UpdatePassword(UpdatePasswordCommand command)
        {
            ModelState.ThrowValidationExceptionIfInvalid<User.Errors>();

            command.Id = User.Claims.GetUserId();
            await commandFactory.Execute(command);
        }
    }
}
