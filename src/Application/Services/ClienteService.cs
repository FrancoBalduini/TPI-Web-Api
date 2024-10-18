using Application.Interfaces;
using Application.Models;
using Application.Models.Request;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces;
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
        private readonly IMapper _mapper;
        public ClienteService(IClienteRepository clienteRepository, IMapper mapper) 
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;

        }

        public ClienteDTO Create(ClienteCreateRequest clienteCreateRequest)
        {
            var cliente = _mapper.Map<Cliente>(clienteCreateRequest);
            _clienteRepository.Add(cliente);
            return _mapper.Map<ClienteDTO>(cliente);
        }

        public List<ClienteDTO> GetAll()
        {
            var clientes = _clienteRepository.GetAll();
            return _mapper.Map<List<ClienteDTO>>(clientes);
        }

        public ClienteDTO GetById(int id) 
        {
            var cliente = _clienteRepository.GetById(id) ?? throw new NotFoundException($"No se encontró el ID ingresado: {id}");
            return _mapper.Map<ClienteDTO>(cliente);
        }

        public void Delete(int id) 
        {
            var clienteid = _clienteRepository.GetById(id) ?? throw new NotFoundException($"No se encontró el ID ingresado: {id}");
            _clienteRepository.Delete(clienteid);
        }

        public void Update(int id, ClienteUpdateRequest clienteUpdateRequest)
        {
            var cliente = _clienteRepository.GetById(id) ?? throw new NotFoundException($"No se encontró el ID ingresado: {id}");
            _mapper.Map(clienteUpdateRequest, cliente);
            _clienteRepository.Update(cliente);

        }
    }
}
