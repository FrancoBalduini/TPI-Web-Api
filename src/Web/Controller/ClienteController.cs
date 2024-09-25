using Application.Interfaces;
using Application.Models.Request;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace web.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        [HttpGet("{id}")]
        public Cliente GetClienteById(int id)
        {
            return _clienteRepository.GetClienteById(id);
        }

        [HttpPost]
        public Cliente CreateCliente(ClienteCreateRequest clienteCreateRequest)
        {
            var cliente = new Cliente
            {
                Nombre = clienteCreateRequest.Nombre,
                Apellido = clienteCreateRequest.Apellido,
                Contrasenia = clienteCreateRequest.Contrasenia,
                Email = clienteCreateRequest.Email,
                NombreUser = clienteCreateRequest.NombreUser
            };

            _clienteRepository.CreateCliente(cliente);
            return cliente;
        }

        [HttpPut]
        public Cliente UpdateCliente(ClienteUpdateRequest clienteUpdateRequest)
        {
            var cliente = _clienteRepository.GetClienteById(clienteUpdateRequest.Id);

            if (cliente == null)
                return null;

            cliente.Nombre = clienteUpdateRequest.Nombre;
            cliente.Apellido = clienteUpdateRequest.Apellido;
            cliente.Email = clienteUpdateRequest.Email;
            cliente.NombreUser = clienteUpdateRequest.NombreUser;

            _clienteRepository.UpdateCliente(cliente);
            return cliente;
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCliente(int id)
        {
            var cliente = _clienteRepository.GetClienteById(id);

            if (cliente == null)
            {
                return NotFound();
            }

            _clienteRepository.DeleteCliente(id); 
            return NoContent(); 
        }

        [HttpGet]
        public IEnumerable<Cliente> GetAllClientes()
        {
            return _clienteRepository.GetAllClientes();
        }
    }
}
