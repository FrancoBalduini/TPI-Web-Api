using System.Security.Claims;
using Application.Interfaces;
using Application.Models;
using Application.Models.Request;
using Application.Services;
using Domain.Entities;
using Domain.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controller
{
    [ApiController]
    [Route("api/[controller]/[Action]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        [Authorize(Roles = "SysAdmin")]
        public ActionResult<List<ClienteDTO>> GetAll() 
        {
            return _clienteService.GetAll();
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "SysAdmin")]
        public ActionResult<ClienteDTO> GetById(int id)
        {
            try
            {
                return _clienteService.GetById(id);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        [Authorize(Roles = "SysAdmin")]
        public ActionResult<ClienteDTO> Create([FromBody]ClienteCreateRequest   clienteCreateRequest) 
        {
            try
            {
                var nuevoCliente = _clienteService.Create(clienteCreateRequest);
                return CreatedAtAction(nameof(GetById), new { id = nuevoCliente.Id }, nuevoCliente);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "SysAdmin")]
        public IActionResult Update([FromRoute]int id,[FromBody] ClienteUpdateRequest clienteUpdateRequest) 
        {
            try
            {
                _clienteService.Update(id, clienteUpdateRequest);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut()]
        [Authorize(Roles = "Cliente")]
        public IActionResult UpdatePersonal([FromBody] ClienteUpdateRequest clienteUpdateRequest)
        {
            try
            {
                var clienteIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (clienteIdClaim == null)
                {
                    return Unauthorized("No se pudo encontrar el Id del cliente.");
                }

                var clienteId = int.Parse(clienteIdClaim);

                _clienteService.Update(clienteId, clienteUpdateRequest);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "SysAdmin")]
        public IActionResult Delete([FromRoute]int id) 
        {
            try
            {
                _clienteService.Delete(id);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
