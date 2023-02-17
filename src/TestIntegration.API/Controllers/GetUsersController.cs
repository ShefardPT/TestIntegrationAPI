﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestIntegration.API.Models;
using TestIntegration.API.Services;

namespace TestIntegration.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class GetUsersController : ControllerBase
    {
        private readonly IAuthorizationService _authorizationService;
        private readonly IUsersInformationService _usersInformationService;

        public GetUsersController(
            IAuthorizationService authorizationService, 
            IUsersInformationService usersInformationService)
        {
            _authorizationService = authorizationService;
            _usersInformationService = usersInformationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var authorizationResult = await _authorizationService.AuthorizeAsync(HttpContext);

                object result;
                if (authorizationResult.Succeeded)
                {
                    result = await _usersInformationService.GetUsersFullInfoAsync();
                }
                else
                {
                    result = await _usersInformationService.GetUsersShortInfoAsync();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }
    }
}