using Application.Interfaces;
using Application.Models.Request;
using Application.Models;
using Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Application.Services;
using System.Security.Claims;

namespace Web.Controller
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class DuenoController : ControllerBase
    {
        private readonly IDuenoService _duenoService;
        public DuenoController(IDuenoService duenoService)
        {
            _duenoService = duenoService;
        }

        [HttpGet]
        [Authorize(Roles = "SysAdmin")]
        public ActionResult<List<DuenoDTO>> GetAll()
        {
            return _duenoService.GetAll();
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "SysAdmin")]
        public ActionResult<DuenoDTO> GetById(int id)
        {
            try
            {
                return _duenoService.GetById(id);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        [Authorize(Roles = "SysAdmin")]
        public ActionResult<DuenoDTO> Create([FromBody] DuenoCreateRequest duenoCreateRequest)
        {
            try
            {
                var nuevoDueno = _duenoService.Create(duenoCreateRequest);
                return CreatedAtAction(nameof(GetById), new { id = nuevoDueno.Id }, nuevoDueno);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "SysAdmin")]
        public IActionResult Update([FromRoute] int id, [FromBody] DuenoUpdateRequest duenoUpdateRequest)
        {
            try
            {
                _duenoService.Update(id, duenoUpdateRequest);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut()]
        [Authorize(Roles = "Dueno, SysAdmin")]
        //SysAdmin no tiene mucho sentido, pero se lo dejamos para que pueda probar el endpoint.
        public IActionResult UpdatePersonal([FromBody] DuenoUpdateRequest duenoUpdateRequest)
        {
            try
            {
                var duenoIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (duenoIdClaim == null)
                {
                    return Unauthorized("No se pudo encontrar el Id del Dueno.");
                }
                var DuenoId = int.Parse(duenoIdClaim);

                _duenoService.Update(DuenoId, duenoUpdateRequest);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "SysAdmin")]
        public IActionResult Delete([FromRoute] int id)
        {
            try
            {
                _duenoService.Delete(id);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
