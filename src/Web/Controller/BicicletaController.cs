using Application.Interfaces;
using Application.Models.Request;
using Application.Models;
using Application.Services;
using Domain.Entities;
using Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class BicicletaController : ControllerBase
    {
        private readonly IBicicletaService _bicicletaService;
            public BicicletaController(IBicicletaService bicicletaService)
            {
                _bicicletaService = bicicletaService;
            }
        

        [HttpGet]
        public ActionResult<List<BicicletaDTO>> GetAll()
        {
            return _bicicletaService.GetAll();

        }


        [HttpGet("{id}")]
        public ActionResult<BicicletaDTO> GetById([FromRoute] int id)
        {
            try
            {
                return _bicicletaService.GetById(id);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }


        [HttpPost]
        public ActionResult<Bicicleta> Create([FromBody] BicicletaCreateRequest bicicletaCreateRequest)
        {
            try
            {
                var nuevoBicicleta = _bicicletaService.Create(bicicletaCreateRequest);
                return CreatedAtAction(nameof(GetById), new { id = nuevoBicicleta.Id }, nuevoBicicleta);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }


        [HttpPut("{id}")]
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
        public ActionResult<List<Bicicleta>> GetBicicletasConClientes(int clienteId)
        {
            var bicicletasConClientes = _bicicletaService.GetBicicletasConClientes(clienteId);
            return Ok(bicicletasConClientes);
        }
    }
}
