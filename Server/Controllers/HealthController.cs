using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using DatingApp.Data.Interfaces;
using DatingApp.Dto;
using DatingApp.Helpers;
using DatingApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Server.Helpers;

namespace DatingApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HealthController : ControllerBase
    {

        public HealthController() { }

        [HttpGet]
        public IActionResult CheckHealth()
        {
            return Ok(new { status = "Ok" });
        }
    }
}
