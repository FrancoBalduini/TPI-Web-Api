using System.Security.Claims;
using Application.Interfaces;
using Application.Models;
using Application.Models.Request;
using Application.Services;
using Domain.Entities;
using Domain.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;



namespace Web.Controller
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class TallerController : ControllerBase
    {
        private readonly ITallerService _tallerService;

        public TallerController(ITallerService tallerService)
        {
            _tallerService = tallerService;
        }

        
        [HttpGet]
        [Authorize(Roles = "SysAdmin, Cliente")]
        public ActionResult<List<TallerDTO>> GetAll()
        {
            return _tallerService.GetAll();
            
        }

        
        [HttpGet("{id}")]
        [Authorize(Roles = "SysAdmin, Dueno")]
        public ActionResult<TallerDTO> GetById([FromRoute] int id)
        {
            try
            {
                var rolUser = User.FindFirst(ClaimTypes.Role)?.Value;
                var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (userIdClaim == null)
                {
                    return Unauthorized("No se pudo encontrar el Id del dueño.");
                }
                var userId = int.Parse(userIdClaim);

                return _tallerService.GetById(id, userId, rolUser);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }


        [HttpPost]
        [Authorize(Roles = "Dueno")]
        public ActionResult<Taller> Create([FromBody] TallerCreateRequest tallerCreateRequest)
        {
            try
            {

                var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (userIdClaim == null)
                {
                    return Unauthorized("No se pudo encontrar el Id del dueño.");
                }

                var userId = int.Parse(userIdClaim);

                var nuevoTaller = _tallerService.Create(tallerCreateRequest, userId);
                return CreatedAtAction(nameof(GetById), new { id = nuevoTaller.Id }, nuevoTaller);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("{userId}")]
        [Authorize(Roles = "SysAdmin")]
        public ActionResult<Taller> CreateByAdmin([FromRoute] int userId, [FromBody] TallerCreateRequest tallerCreateRequest)
        {
            try
            {
                var nuevoTaller = _tallerService.Create(tallerCreateRequest, userId);
                return CreatedAtAction(nameof(GetById), new { id = nuevoTaller.Id }, nuevoTaller);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }


        [HttpPut("{id}")]
        [Authorize(Roles = "SysAdmin, Dueno")]
     
        public IActionResult Update([FromRoute] int id, [FromBody] TallerUpdateRequest tallerUpdateRequest)
        {
            try
            {
                var rolUser = User.FindFirst(ClaimTypes.Role)?.Value;
                var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (userIdClaim == null)
                {
                    return Unauthorized("No se pudo encontrar el Id del dueño.");
                }

                var userId = int.Parse(userIdClaim);

                _tallerService.Update(id, userId, rolUser, tallerUpdateRequest);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        
        [HttpDelete("{id}")]
        [Authorize(Roles = "SysAdmin, Dueno")]

        public IActionResult Delete([FromRoute] int id)
        {
            try
            {
                var rolUser = User.FindFirst(ClaimTypes.Role)?.Value;
                var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (userIdClaim == null)
                {
                    return Unauthorized("No se pudo encontrar el Id del dueño.");
                }

                var userId = int.Parse(userIdClaim);

                _tallerService.Delete(id, userId, rolUser);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
        
        
        [HttpGet("Duenos")]
        [Authorize(Roles = "Dueno")]
        
        public ActionResult<List<Taller>> GetTalleresDelDueno()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userIdClaim == null)
            {
                return Unauthorized("No se pudo encontrar el Id del dueño.");
            }

            var userId = int.Parse(userIdClaim);

            var tallerDelDueno = _tallerService.GetTallerConDuenos(userId);
            return Ok(tallerDelDueno);
        }
    }
}

