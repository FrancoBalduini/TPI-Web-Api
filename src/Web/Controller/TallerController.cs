﻿using Application.Interfaces;
using Application.Models;
using Application.Models.Request;
using Domain.Entities;
using Domain.Exceptions;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "SysAdmin")]
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
                return _tallerService.GetById(id);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        
        [HttpPost]
        [Authorize(Roles = "SysAdmin, Dueno")]
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
        [Authorize(Roles = "SysAdmin, Dueno")]
        //los personales
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
        [Authorize(Roles = "SysAdmin, Dueno")]
        //los personales
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
        
        
        [HttpGet("Duenos/{DuenoId}")]
        [Authorize(Roles = "SysAdmin, Dueno")]
        //cambiar nombre
        public ActionResult<List<Taller>> GetTalleresConDuenos(int DuenoId)
        {
            var talleresConDuenos = _tallerService.GetTallerConDuenos(DuenoId);
            return Ok(talleresConDuenos);
        }
    }
}

