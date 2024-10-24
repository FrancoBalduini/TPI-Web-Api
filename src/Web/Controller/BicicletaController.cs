using Application.Interfaces;
using Application.Models.Request;
using Application.Models;
using Application.Services;
using Domain.Entities;
using Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Web.Controller
{
    [ApiController]
    [Route("api/[controller]/[Action]")]
    public class BicicletaController : ControllerBase
    {
        private readonly IBicicletaService _bicicletaService;
        public BicicletaController(IBicicletaService bicicletaService)
        {
            _bicicletaService = bicicletaService;
        }


        [HttpGet]
        [Authorize(Roles = "SysAdmin")]
        public ActionResult<List<BicicletaDTO>> GetAll()
        {
            return _bicicletaService.GetAll();

        }


        [HttpGet("{id}")]
        [Authorize(Roles = "Cliente")]
        public ActionResult<BicicletaDTO> GetById([FromRoute] int id)
        {
            try
            {
                var clienteIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (clienteIdClaim == null)
                {
                    return Unauthorized("No se pudo encontrar el Id del cliente.");
                }

                var clienteId = int.Parse(clienteIdClaim);

                return _bicicletaService.GetById(id, clienteId);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "SysAdmin")]
        public ActionResult<BicicletaDTO> GetByIdAdmin([FromRoute] int id)
        {
            try
            {
                return _bicicletaService.GetById(id); //aaaaaaaarreglar
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }


        [HttpPost]
        [Authorize(Roles = "Cliente")]
        public ActionResult<Bicicleta> Create([FromBody] BicicletaCreateRequest bicicletaCreateRequest)
        {
            try
            {

                var clienteIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (clienteIdClaim == null)
                {
                    return Unauthorized("No se pudo encontrar el Id del cliente.");
                }

                var clienteId = int.Parse(clienteIdClaim);

                var nuevoBicicleta = _bicicletaService.Create(bicicletaCreateRequest, clienteId);
                return CreatedAtAction(nameof(GetById), new { id = nuevoBicicleta.Id }, nuevoBicicleta);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("{clienteId}")]
        [Authorize(Roles = "SysAdmin")]
        public ActionResult<Bicicleta> CreateByAdmin([FromRoute]int clienteId, [FromBody] BicicletaCreateRequest bicicletaCreateRequest)
        {
            try
            {
                var nuevoBicicleta = _bicicletaService.Create(bicicletaCreateRequest, clienteId);
                return CreatedAtAction(nameof(GetById), new { id = nuevoBicicleta.Id }, nuevoBicicleta);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "SysAdmin, Cliente")]
        //q updatee las suyas
        public IActionResult Update([FromRoute] int id, [FromBody] BicicletaUpdateRequest bicicletaUpdateRequest)
        {
            try
            {
                _bicicletaService.Update(id, bicicletaUpdateRequest);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }


        [HttpDelete("{id}")]
        [Authorize(Roles = "SysAdmin, Cliente")]
        //q solo borre las suyas
        public IActionResult Delete([FromRoute] int id)
        {
            try
            {
                _bicicletaService.Delete(id);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }


        [HttpGet("clientes/{clienteId}")]
        [Authorize(Roles = "Cliente")]
        //cambiar nombre y agregar el de sysamdin
        public ActionResult<List<Bicicleta>> GetBicicletasConClientes(int clienteId)
        {
            var bicicletasConClientes = _bicicletaService.GetBicicletasConClientes(clienteId);
            return Ok(bicicletasConClientes);
        }
    }
}
