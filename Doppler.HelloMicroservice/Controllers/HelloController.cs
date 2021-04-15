using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Doppler.HelloMicroservice.DopplerSecurity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Doppler.HelloMicroservice.Controllers
{
    [Authorize]
    [ApiController]
    public class HelloController
    {
        [AllowAnonymous]
        [HttpGet("/hello/anonymous")]
        public string GetForAnonymous()
        {
            return "Hello anonymous!";
        }

        [HttpGet("/hello/valid-token")]
        public string GetForValidToken()
        {
            return "Hello! you have a valid token!";
        }

        [Authorize(Policies.ONLY_SUPERUSER)]
        [HttpGet("/hello/superuser")]
        public string GetForSuperUserToken()
        {
            return "Hello! you have a valid SuperUser token!";
        }
    }
}
