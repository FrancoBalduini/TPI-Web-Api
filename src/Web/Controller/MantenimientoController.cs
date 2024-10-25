using Application.Interfaces;
using Application.Models;
using Application.Models.Request;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Web.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class MantenimientoController : ControllerBase
    {
        private readonly IMantenimientoService _service;
        private readonly IMapper _mapper;

        public MantenimientoController(IMantenimientoService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "SysAdmin, Cliente")]
        // falta probar con id de user cliente o dueño
        public ActionResult<MantenimientoDTO> GetById([FromRoute] int id) 
        {
            try
            {
                var rolCliente = User.FindFirst(ClaimTypes.Role)?.Value;
                var clienteIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (clienteIdClaim == null)
                {
                    return Unauthorized("No se pudo encontrar el Id del cliente.");
                }
                var clienteId = int.Parse(clienteIdClaim);

                return _service.GetById(id, clienteId, rolCliente);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        [Authorize(Roles = "SysAdmin")]
        public ActionResult<List<MantenimientoDTO>> GetAll()
        {
            return _service.GetAll();
        }

        [HttpPost]
        [Authorize(Roles = "SysAdmin, Cliente")]
        public ActionResult<MantenimientoDTO> Create([FromBody]MantenimientoCreateRequest request)
        {
            try
            {
                var rolCliente = User.FindFirst(ClaimTypes.Role)?.Value;
                var clienteIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (clienteIdClaim == null)
                {
                    return Unauthorized("No se pudo encontrar el Id del cliente.");
                }
            
                var clienteId = int.Parse(clienteIdClaim);
                var mantenimientoCrear = _service.Create(request, clienteId , rolCliente);

                return CreatedAtAction(nameof(GetById), new { id = mantenimientoCrear.Id }, mantenimientoCrear);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "SysAdmin, Dueno, Cliente")]
        // los personales (hacer endpoint de cliente de cancelar)
        public IActionResult Update([FromRoute] int id, [FromBody] MantenimientoUpdateRequest request)
        {
            try
            {
                var rolLogged = User.FindFirst(ClaimTypes.Role)?.Value;
                var loggedIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (loggedIdClaim == null)
                {
                    return Unauthorized("No se pudo encontrar el Id del Usuario.");
                }

                var loggedId = int.Parse(loggedIdClaim);
                _service.Update(id, loggedId, rolLogged, request);
                return NoContent();
            }
            catch   (NotFoundException ex)
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
                _service.Delete(id);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        } 
        //hacer endpoint de cancelar mantenimiento
    }
}
