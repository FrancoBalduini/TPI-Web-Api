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

namespace Application.Services
{
    public class BicicletaService : IBicicletaService
    {
            private readonly IBicicletaRepository _bicicletaRepository;
            private readonly IMapper _mapper;
        
            public BicicletaService(IBicicletaRepository BicicletaRepository, IMapper mapper)
            {
                _bicicletaRepository = BicicletaRepository;
                _mapper = mapper;
            }

            public BicicletaDTO Create(BicicletaCreateRequest bicicletaCreateRequest)
            {

                var bicicleta = _mapper.Map<Bicicleta>(bicicletaCreateRequest);
                _bicicletaRepository.Add(bicicleta);
                return _mapper.Map<BicicletaDTO>(bicicleta);
            }

            public void Delete(int id)
            {
                var bicicleta = _bicicletaRepository.GetById(id) ?? throw new NotFoundException($"No se encontró el ID ingresado: {id}");
                _bicicletaRepository.Delete(bicicleta);
            }

            public List<BicicletaDTO> GetAll()
            {

                var bicicletas = _bicicletaRepository.GetAll();
                return _mapper.Map<List<BicicletaDTO>>(bicicletas);
            }

            public BicicletaDTO GetById(int id)
            {
                var bicicleta = _bicicletaRepository.GetById(id) ?? throw new NotFoundException($"No se encontró el ID ingresado: {id}");
                return _mapper.Map<BicicletaDTO>(bicicleta);
            }

            public void Update(int id, BicicletaUpdateRequest bicicletaUpdateRequest)
            {
                var bicicleta = _bicicletaRepository.GetById(id) ?? throw new NotFoundException($"No se encontró el ID ingresado: {id}");
                _mapper.Map(bicicletaUpdateRequest, bicicleta);
                _bicicletaRepository.Update(bicicleta);
            }

            public List<Bicicleta> GetBicicletasConClientes(int clienteId)
            {
                return _bicicletaRepository.GetBicicletasConClientes(clienteId);
            }
        
    }
}
