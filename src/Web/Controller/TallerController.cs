using Application.Interfaces;
using Application.Models;
using Application.Models.Request;
using Domain.Entities;
using Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;



namespace Web.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TallerController : ControllerBase
    {
        private readonly ITallerService _tallerService;

        public TallerController(ITallerService tallerService)
        {
            _tallerService = tallerService;
        }

        
        [HttpGet]
        public ActionResult<List<TallerDTO>> GetAll()
        {
            return _tallerService.GetAll();
            
        }

        
        [HttpGet("{id}")]
        public ActionResult<TallerDTO> GetById([FromRoute] int id)
        {
            try
            {
                return _tallerService.GetById(id);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        
        [HttpPost]
        public ActionResult<Taller> Create([FromBody] TallerCreateRequest tallerCreateRequest)
        {
            try
            {
                var nuevoTaller = _tallerService.Create(tallerCreateRequest);
                return CreatedAtAction(nameof(GetById), new { id = nuevoTaller.Id }, nuevoTaller);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        
        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] TallerUpdateRequest tallerUpdateRequest)
        {
            try
            {
                _tallerService.Update(id, tallerUpdateRequest);
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
                _tallerService.Delete(id);
                return NoContent(); 
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message); 
            }
        }

        
        [HttpGet("dueños/{dueñoId}")]
        public ActionResult<List<Taller>> GetTalleresConDueños(int dueñoId)
        {
            var talleresConDueños = _tallerService.GetTallerConDueños(dueñoId);
            return Ok(talleresConDueños);
        }
    }
}

