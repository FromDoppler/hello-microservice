using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Doppler.HelloMicroservice.Controllers
{
    [ApiController]
    public class HelloController
    {
        [HttpGet("/hello/anonymous")]
        public string GetForAnonymous()
        {
            return "Hello anonymous!";
        }
    }
}
