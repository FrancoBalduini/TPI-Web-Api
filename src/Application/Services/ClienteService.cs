using Application.Interfaces;
using Application.Models;
using Application.Models.Request;
using Domain.Entities;
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

        public List<ClienteDTO> GetAll()
        {

            return new List<ClienteDTO>();
        }
    }
}
