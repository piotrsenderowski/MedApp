﻿using MedApp.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace MedApp.Api.Controllers
{
    [Route("")]
    public class HomeController : ControllerBase
    {
        private readonly string _name;
        public HomeController(IOptions<AppOptions> options)
        {
            _name = options.Value.Name;
        }
        [HttpGet]
        public ActionResult<string> Get() => _name;
    }
}
