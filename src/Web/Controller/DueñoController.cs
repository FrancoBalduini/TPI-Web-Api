using Application.Interfaces;
using Application.Models.Request;
using Application.Models;
using Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class DueñoController : ControllerBase
    {
        private readonly IDueñoService _dueñoService;
        public DueñoController(IDueñoService dueñoService)
        {
            _dueñoService = dueñoService;
        }

        [HttpGet]
        public ActionResult<List<DueñoDTO>> GetAll()
        {
            return _dueñoService.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<DueñoDTO> GetById(int id)
        {
            try
            {
                return _dueñoService.GetById(id);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<DueñoDTO> Create([FromBody] DueñoCreateRequest dueñoCreateRequest)
        {
            try
            {
                var nuevoDueño = _dueñoService.Create(dueñoCreateRequest);
                return CreatedAtAction(nameof(GetById), new { id = nuevoDueño.Id }, nuevoDueño);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] DueñoUpdateRequest dueñoUpdateRequest)
        {
            try
            {
                _dueñoService.Update(id, dueñoUpdateRequest);
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
                _dueñoService.Delete(id);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
