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
    public class DuenoController : ControllerBase
    {
        private readonly IDuenoService _DuenoService;
        public DuenoController(IDuenoService DuenoService)
        {
            _DuenoService = DuenoService;
        }

        [HttpGet]
        public ActionResult<List<DuenoDTO>> GetAll()
        {
            return _DuenoService.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<DuenoDTO> GetById(int id)
        {
            try
            {
                return _DuenoService.GetById(id);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<DuenoDTO> Create([FromBody] DuenoCreateRequest DuenoCreateRequest)
        {
            try
            {
                var nuevoDueno = _DuenoService.Create(DuenoCreateRequest);
                return CreatedAtAction(nameof(GetById), new { id = nuevoDueno.Id }, nuevoDueno);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] DuenoUpdateRequest DuenoUpdateRequest)
        {
            try
            {
                _DuenoService.Update(id, DuenoUpdateRequest);
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
                _DuenoService.Delete(id);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
