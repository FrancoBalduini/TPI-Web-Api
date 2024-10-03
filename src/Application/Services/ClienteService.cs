using Application.Interfaces;
using Application.Models;
using Application.Models.Request;
using Domain.Entities;
using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        public ClienteService(IClienteRepository clienteRepository) 
        {
            _clienteRepository = clienteRepository;

        }

        public Cliente Create(Cliente cliente)
        {
            _clienteRepository.Add(cliente);
            return cliente;
        }

        public List<Cliente> GetAll()
        {
            return _clienteRepository.GetAll();
        }

        public Cliente GetById(int id) 
        {
            var cliente = _clienteRepository.GetById(id) ?? throw new NotFoundException($"No se encontró el ID ingresado: {id}");
            return cliente;
        }

        public void Delete(int id) 
        {
            var clienteid = _clienteRepository.GetById(id) ?? throw new NotFoundException($"No se encontró el ID ingresado: {id}");
            _clienteRepository.Delete(clienteid);
        }

        public void Update(int id, Cliente cliente)
        {
            var clienteidUpdate = _clienteRepository.GetById(id) ?? throw new NotFoundException($"No se encontró el ID ingresado: {id}");
            clienteidUpdate.Nombre = cliente.Nombre;
            clienteidUpdate.Apellido = cliente.Apellido;
            clienteidUpdate.Email = cliente.Email;
            clienteidUpdate.Contrasenia = cliente.Contrasenia;
            clienteidUpdate.NombreUser = cliente.NombreUser;
            _clienteRepository.Update(clienteidUpdate);
        }
    }
}
