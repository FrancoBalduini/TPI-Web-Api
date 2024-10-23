using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.Models;
using Application.Models.Request;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces;

namespace Application.Services
{
    public class MantenimientoService : IMantenimientoService
    {
        private readonly IMantenimientoRepository _repository;
        private readonly IMapper _mapper;

        public MantenimientoService(IMantenimientoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public MantenimientoDTO GetById(int id) 
        {
            var mantenimiento = _repository.GetById(id) ?? throw new NotFoundException($"No se encontro el id: {id}");
            return _mapper.Map<MantenimientoDTO>(mantenimiento);
        }

        public List<MantenimientoDTO> GetAll() 
        { 
            var ListaMantenimiento = _repository.GetAll();
            return _mapper.Map<List<MantenimientoDTO>>(ListaMantenimiento);
        }

        public MantenimientoDTO Create(MantenimientoCreateRequest request)
        {
            var mantenimientoAgregar = _mapper.Map<Mantenimiento>(request);
            _repository.Add(mantenimientoAgregar);
            return _mapper.Map<MantenimientoDTO>(mantenimientoAgregar);
        }

        public void Update(int id, MantenimientoUpdateRequest request)
        {
            var mantenimientoUpdatear = _repository.GetById(id) ?? throw new NotFoundException($"No se encontro el id: {id}");
            _mapper.Map(request, mantenimientoUpdatear);
            _repository.Update(mantenimientoUpdatear);
        }

        public void Delete(int id)
        {
            var borrar = _repository.GetById(id) ?? throw new NotFoundException($"No se encontro el id: {id}");
            _repository.Delete(borrar);
        }
    }
}
