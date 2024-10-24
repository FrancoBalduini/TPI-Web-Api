using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.Models.Request;
using Application.Models;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces;
using System.Security.Claims;
using Domain.Enums;

namespace Application.Services
{
    public class BicicletaService : IBicicletaService
    {
            private readonly IBicicletaRepository _bicicletaRepository;
            private readonly IMapper _mapper;
            private readonly IClienteRepository _clienteRepository;
        
            public BicicletaService(IBicicletaRepository BicicletaRepository, IMapper mapper, IClienteRepository clienteRepository)
            {
                _bicicletaRepository = BicicletaRepository;
                _mapper = mapper;
                _clienteRepository = clienteRepository;
            }

        public BicicletaDTO Create(BicicletaCreateRequest bicicletaCreateRequest, int clienteIdToken)
        {
            // Buscar el cliente en el repositorio o servicio usando el idToken
            var cliente = GetCliente(clienteIdToken);

            // Mapear el request a la entidad Bicicleta
            var bicicleta = _mapper.Map<Bicicleta>(bicicletaCreateRequest);

            // Asignar el cliente a la bicicleta
            bicicleta.Cliente = cliente;

            // Guardar la bicicleta en la base de datos
            _bicicletaRepository.Add(bicicleta);

            // Devolver el DTO de la bicicleta creada
            return _mapper.Map<BicicletaDTO>(bicicleta);
        }

        public void Delete(int id, int idLogged, string rolLogged)
            {
            var borrar = _bicicletaRepository.GetById(id) ?? throw new NotFoundException($"No se encontró el ID ingresado: {id}");
            if (rolLogged == "SysAdmin")
            {
                _bicicletaRepository.Delete(borrar);
            }
            else
            {
                var cliente = GetCliente(idLogged);
                if (borrar.Cliente == cliente)
                    _bicicletaRepository.Delete(borrar);
                else
                    throw new NotFoundException($"Esa bicicleta no le pertenece");
            }
            
        }

            public List<BicicletaDTO> GetAll()
            {

                var bicicletas = _bicicletaRepository.GetAll();
                return _mapper.Map<List<BicicletaDTO>>(bicicletas);
            }

            public BicicletaDTO GetById(int id, int idLogged, string rolLogged)
            {
                var bicicleta = _bicicletaRepository.GetById(id) ?? throw new NotFoundException($"No se encontró el ID ingresado: {id}");
                if (rolLogged == "SysAdmin")
                {
                    return _mapper.Map<BicicletaDTO>(bicicleta);
                }
                var cliente = GetCliente(idLogged);
            
                if (bicicleta.Cliente == cliente)
                    return _mapper.Map<BicicletaDTO>(bicicleta);
                else
                    throw new NotFoundException($"Esa bicicleta no le pertenece");
            }
        
            public void Update(int id, BicicletaUpdateRequest bicicletaUpdateRequest)
            {
                var bicicleta = _bicicletaRepository.GetById(id) ?? throw new NotFoundException($"No se encontró el ID ingresado: {id}");
                _mapper.Map(bicicletaUpdateRequest, bicicleta);
                _bicicletaRepository.Update(bicicleta);
            }

            public List<Bicicleta> GetBicicletasConCliente(int clienteId)
            {
                return _bicicletaRepository.GetBicicletasConClientes(clienteId);
            }


            public Cliente GetCliente(int clienteId)
            {
                var cliente = _clienteRepository.GetByIdToken(clienteId);
                if (cliente == null)
                {
                    throw new NotFoundException("Cliente no encontrado con el idToken proporcionado.");
                }
                return cliente;
            }
    }
}
