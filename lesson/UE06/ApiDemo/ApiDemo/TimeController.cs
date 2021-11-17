using Microsoft.AspNetCore.Mvc;
using System;

namespace ApiDemo
{
    [Route("api")]
    [ApiController]
    public class TimeController: ControllerBase
    {
        [HttpGet("time2")]
        [Produces("application/json")]
        public ActionResult<object> Get()
        {
            return new { Time = DateTime.Now };
        }
    }
}
