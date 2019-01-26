// Copyright (c) ProjectName. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using ProjectName.Domain.Users.Dtos;
using ProjectName.Shared.Exceptions;

namespace ProjectName.Web.Api.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ExceptionController : ControllerBase
    {
        private readonly ILogger<ExceptionController> logger;

        public ExceptionController(ILogger<ExceptionController> logger)
        {
            this.logger = logger;
        }

        [HttpPost]
        public ActionResult Log([FromBody]ErrorWithContext error)
        {
            logger.LogError(
                new ClientException(),
                "{@name} -- {@appId} | userId: {@userId} | status: {@status} | url: '{@url}' | '{@message}' | '{@stack}'",
                error.Name,
                error.AppId,
                error.User?.Id,
                error.Status,
                error.Url,
                error.Message,
                error.Stack);
            return Ok();
        }

        public class ErrorWithContext
        {
            public string AppId { get; set; }

            public string Name { get; set; }

            public string Message { get; set; }

            public string Stack { get; set; }

            public int? Status { get; set; }

            public string Url { get; set; }

            public UserDto User { get; set; }
        }
    }
}
