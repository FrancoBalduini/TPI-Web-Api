using Application.Interfaces;
using Application.Models;
using Application.Models.Request;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        // rol
        public ActionResult<MantenimientoDTO> GetById([FromRoute] int id) 
        {
            try
            {
                return _service.GetById(id);
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
                var mantenimientoCrear = _service.Create(request);
                return CreatedAtAction(nameof(GetById), new { id = mantenimientoCrear.Id }, mantenimientoCrear);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "SysAdmin, Dueno")]
        // los personales (hacer endpoint de cliente de cancelar)
        public IActionResult Update([FromRoute] int id, [FromBody] MantenimientoUpdateRequest request)
        {
            try
            {
                _service.Update(id, request);
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
