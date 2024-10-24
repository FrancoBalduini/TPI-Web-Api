﻿using Application.Interfaces;
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
        [Authorize(Roles =  "SysAdmin, Cliente")]
        public ActionResult<BicicletaDTO> GetById([FromRoute] int id)
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

                return _bicicletaService.GetById(id, clienteId, rolCliente);
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
        public IActionResult Update([FromRoute] int id, [FromBody] BicicletaUpdateRequest bicicletaUpdateRequest)
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

                _bicicletaService.Update(id, clienteId, rolCliente, bicicletaUpdateRequest);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }


        [HttpDelete("{id}")]
        [Authorize(Roles = "SysAdmin, Cliente")]
        public IActionResult Delete([FromRoute] int id)
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
                _bicicletaService.Delete(id, clienteId, rolCliente);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }


        [HttpGet]
        [Authorize(Roles = "Cliente")]
        
        public ActionResult<List<Bicicleta>> GetBicicletasClienteLogged()
        {
            var clienteIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (clienteIdClaim == null)
            {
                return Unauthorized("No se pudo encontrar el Id del cliente.");
            }

            var clienteId = int.Parse(clienteIdClaim);

            var bicicletasConClientes = _bicicletaService.GetBicicletasConCliente(clienteId);
            return Ok(bicicletasConClientes);
        }
    }
}
