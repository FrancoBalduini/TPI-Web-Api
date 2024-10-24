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
    public class DuenoService : IDuenoService
    {
        private readonly IDuenoRepository _DuenoRepository;
        private readonly IMapper _mapper;

        public DuenoService(IDuenoRepository DuenoRepository, IMapper mapper)
        {
            _DuenoRepository = DuenoRepository;
            _mapper = mapper;
        }

        public DuenoDTO Create(DuenoCreateRequest DuenoCreateRequest)
        {
            var Dueno = _mapper.Map<Dueno>(DuenoCreateRequest);
            _DuenoRepository.Add(Dueno);
            return _mapper.Map<DuenoDTO>(Dueno);
        }

        public List<DuenoDTO> GetAll()
        {
            var Duenos = _DuenoRepository.GetAll();
            return _mapper.Map<List<DuenoDTO>>(Duenos);
        }

        public DuenoDTO GetById(int id)
        {
            var Dueno = _DuenoRepository.GetById(id) ?? throw new NotFoundException($"No se encontró el ID ingresado: {id}");
            return _mapper.Map<DuenoDTO>(Dueno);
        }

        public void Delete(int id)
        {
            var DuenoId = _DuenoRepository.GetById(id) ?? throw new NotFoundException($"No se encontró el ID ingresado: {id}");
            _DuenoRepository.Delete(DuenoId);
        }

        public void Update(int id, DuenoUpdateRequest DuenoUpdateRequest)
        {
            var Dueno = _DuenoRepository.GetById(id) ?? throw new NotFoundException($"No se encontró el ID ingresado: {id}");
            _mapper.Map(DuenoUpdateRequest, Dueno);
            _DuenoRepository.Update(Dueno);

        }
    }
}
