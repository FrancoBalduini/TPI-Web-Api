using Application.Interfaces;
using Application.Models;
using Application.Models.Request;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces;
using System.Collections.Generic;

namespace Application.Services
{
    public class TallerService : ITallerService
    {
        private readonly ITallerRepository _tallerRepository;
        private readonly IMapper _mapper;

        public TallerService(ITallerRepository tallerRepository, IMapper mapper)
        {
            _tallerRepository = tallerRepository;
            _mapper = mapper;
        }

        public TallerDTO Create(TallerCreateRequest tallerCreateRequest)
        {
            
            var taller = _mapper.Map<Taller>(tallerCreateRequest);
            _tallerRepository.Add(taller);
            return _mapper.Map<TallerDTO>(taller);
        }

        public void Delete(int id)
        {
            var taller = _tallerRepository.GetById(id) ?? throw new NotFoundException($"No se encontró el ID ingresado: {id}");
            _tallerRepository.Delete(taller);
        }

        public List<TallerDTO> GetAll()
        {
            
            var talleres = _tallerRepository.GetAll();
            return _mapper.Map<List<TallerDTO>>(talleres);
        }

        public TallerDTO GetById(int id)
        {
            var taller = _tallerRepository.GetById(id) ?? throw new NotFoundException($"No se encontró el ID ingresado: {id}");
            return _mapper.Map<TallerDTO>(taller);
        }

        public void Update(int id, TallerUpdateRequest tallerUpdateRequest)
        {
            var taller = _tallerRepository.GetById(id) ?? throw new NotFoundException($"No se encontró el ID ingresado: {id}");
            _mapper.Map(tallerUpdateRequest, taller);
            _tallerRepository.Update(taller);
        }

        public List<Taller> GetTallerConDuenos(int DuenoId)
        {
            return _tallerRepository.GetTallerConDuenos(DuenoId);
        }
    }
}
