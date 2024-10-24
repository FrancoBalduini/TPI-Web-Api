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
            _authenticationService = authenticationService; //Inyectamos el servicio de autenticación
        }

        /// <summary>
        /// Authenticates a user.
        /// </summary>
        /// <remarks>
        /// Returns a JWT token for the user logged in, with a role claim matching the userType passed in the body.
        /// UserType value must be "Dueno", "Cliente" or "SysAdmin", case sensitive.
        /// </remarks>
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
