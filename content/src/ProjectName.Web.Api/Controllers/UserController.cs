// Copyright (c) ProjectName. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using ProjectName.Abstract;
using ProjectName.Domain.Users.Commands;
using ProjectName.Domain.Users.Dtos;
using ProjectName.Domain.Users.Entities;
using ProjectName.Domain.Users.Queries;
using ProjectName.Web.Api.Utils;

namespace ProjectName.Web.Api.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ICommandFactory commandFactory;
        private readonly IQueryFactory queryFactory;

        public UserController(ICommandFactory commandFactory, IQueryFactory queryFactory)
        {
            this.commandFactory = commandFactory;
            this.queryFactory = queryFactory;
        }

        [HttpPost]
        public async Task<IActionResult> Authorize(
            AuthorizeUserCommand command)
        {
            ModelState.ThrowValidationExceptionIfInvalid<User.Errors>();

            var user = await queryFactory.ResolveQuery<UserByLoginAndPasswordQuery>()
                .Execute(command.Login, command.Password);
            return Ok(GetTokenData(user));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetInfo(int id)
        {
            var response = await queryFactory.ResolveQuery<UserByIdQuery>().Execute(id);
            return Ok(AutoMapper.Mapper.Map<User, UserDto>(response));
        }

        [HttpPut]
        public async Task<IActionResult> Register(
            RegisterUserCommand command)
        {
            ModelState.ThrowValidationExceptionIfInvalid<User.Errors>();

            await commandFactory.Execute(command);
            var user = await queryFactory.ResolveQuery<UserByLoginAndPasswordQuery>()
                .Execute(command.Login, command.Password);
            return Ok(GetTokenData(user));
        }

        private static string BuildJwt(ClaimsIdentity identity)
        {
            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                AuthOptions.ISSUER,
                AuthOptions.AUDIENCE,
                identity.Claims,
                now,
                now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        private static ClaimsIdentity GetIdentity(User user)
        {
            var claims = new List<Claim>
            {
                new Claim("id", user.Id.ToString()),
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Nickname),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.ToString())
            };
            return new ClaimsIdentity(
                claims,
                "Token",
                ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
        }

        private static string GetTokenData(User user)
        {
            var response = new
            {
                access_token = BuildJwt(GetIdentity(user)),
                user = AutoMapper.Mapper.Map<User, UserDto>(user)
            };

            return JsonConvert.SerializeObject(response, Shared.Utils.JsonSettings);
        }
    }
}
