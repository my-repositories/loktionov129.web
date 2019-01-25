using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

using ProjectName.Domain;

namespace ProjectName.Web
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Class1.GetData();
        }
    }
}
