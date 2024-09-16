using Application.Interfaces;
using Application.Models.Request;
using Application.Models.Requests;
using Domain.Entities;
using Domain.Interfaces;
using System.Collections.Generic;

namespace Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public Cliente GetClienteById(int id)
        {
            return _clienteRepository.GetClienteById(id);
        }

        public IEnumerable<Cliente> GetAllClientes()
        {
            return _clienteRepository.GetAllClientes();
        }

        public void CreateCliente(ClienteCreateRequest clienteCreateRequest)
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
        }

        public void UpdateCliente(ClienteUpdateRequest clienteUpdateRequest)
        {
            var cliente = new Cliente
            {
                Id = clienteUpdateRequest.Id,
                Nombre = clienteUpdateRequest.Nombre,
                Apellido = clienteUpdateRequest.Apellido,
                Email = clienteUpdateRequest.Email,
                NombreUser = clienteUpdateRequest.NombreUser
            };

            _clienteRepository.UpdateCliente(cliente);
        }

        public void DeleteCliente(int id)
        {
            _clienteRepository.DeleteCliente(id);
        }
    }
}
