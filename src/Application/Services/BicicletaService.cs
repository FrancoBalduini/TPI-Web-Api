﻿using System;
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
using System.Collections;

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

            var bicicleta = _mapper.Map<Bicicleta>(bicicletaCreateRequest);

            bicicleta.Cliente = cliente;

            _bicicletaRepository.Add(bicicleta);

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
        
            public void Update(int id, int clienteId, string rolCliente, BicicletaUpdateRequest bicicletaUpdateRequest)
            {
                var bicicleta = _bicicletaRepository.GetById(id) ?? throw new NotFoundException($"No se encontró el ID ingresado: {id}");
                _mapper.Map(bicicletaUpdateRequest, bicicleta);
                if (rolCliente == "SysAdmin")
                {
                    _bicicletaRepository.Update(bicicleta);
                }
                else 
                {
                    var cliente = GetCliente(clienteId);
                
                    if (bicicleta.Cliente == cliente)
                        _bicicletaRepository.Update(bicicleta);
                    else
                        throw new NotFoundException($"Esa bicicleta no le pertenece");
                }

            }

            public List<BicicletaDTO> GetBicicletasConCliente(int clienteId)
            {
                var lista = _bicicletaRepository.GetBicicletasConClientes(clienteId);
                var listaMostrar = lista.Select(b => BicicletaDTO.Create(b)).ToList();

                return listaMostrar;
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
