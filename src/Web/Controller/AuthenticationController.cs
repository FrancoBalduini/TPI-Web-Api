using Application.Interfaces;
using Application.Models.Request;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Web.Controller
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("authenticate")]
        public ActionResult<string> Autenticar(AuthenticationRequest authenticationRequest)
        {
            try
            {

                string token = _authenticationService.Autenticar(authenticationRequest);

                return Ok(token);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }
    }
}
