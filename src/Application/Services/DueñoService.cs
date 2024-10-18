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
using Domain.Interfaces;
using Domain.Exceptions;

namespace Application.Services
{
    public class DueñoService : IDueñoService
    {
        private readonly IDueñoRepository _dueñoRepository;
        private readonly IMapper _mapper;

        public DueñoService(IDueñoRepository dueñoRepository, IMapper mapper)
        {
            _dueñoRepository = dueñoRepository;
            _mapper = mapper;
        }

        public DueñoDTO Create(DueñoCreateRequest dueñoCreateRequest)
        {
            var dueño = _mapper.Map<Dueño>(dueñoCreateRequest);
            _dueñoRepository.Add(dueño);
            return _mapper.Map<DueñoDTO>(dueño);
        }

        public List<DueñoDTO> GetAll()
        {
            var dueños = _dueñoRepository.GetAll();
            return _mapper.Map<List<DueñoDTO>>(dueños);
        }

        public DueñoDTO GetById(int id)
        {
            var dueño = _dueñoRepository.GetById(id) ?? throw new NotFoundException($"No se encontró el ID ingresado: {id}");
            return _mapper.Map<DueñoDTO>(dueño);
        }

        public void Delete(int id)
        {
            var dueñoId = _dueñoRepository.GetById(id) ?? throw new NotFoundException($"No se encontró el ID ingresado: {id}");
            _dueñoRepository.Delete(dueñoId);
        }

        public void Update(int id, DueñoUpdateRequest dueñoUpdateRequest)
        {
            var dueño = _dueñoRepository.GetById(id) ?? throw new NotFoundException($"No se encontró el ID ingresado: {id}");
            _mapper.Map(dueñoUpdateRequest, dueño);
            _dueñoRepository.Update(dueño);

        }
    }
}
