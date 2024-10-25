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
        private readonly IDuenoRepository _duenoRepository;
        private readonly IMapper _mapper;

        public TallerService(ITallerRepository tallerRepository, IDuenoRepository duenoRepository ,IMapper mapper)
        {
            _tallerRepository = tallerRepository;
            _duenoRepository = duenoRepository;
            _mapper = mapper;
        }

        public TallerDTO Create(TallerCreateRequest tallerCreateRequest, int duenoIdToken)
        {     
            var dueno = GetDueno(duenoIdToken);           
            var taller = _mapper.Map<Taller>(tallerCreateRequest);
            taller.Dueno = dueno;
            _tallerRepository.Add(taller);
            return _mapper.Map<TallerDTO>(taller);

        }

        public void Delete(int id, int idLogged, string rolLogged)
        {
            var borrar = _tallerRepository.GetById(id) ?? throw new NotFoundException($"No se encontró el ID ingresado: {id}");
            if (rolLogged == "SysAdmin")
            {
                _tallerRepository.Delete(borrar);
            }
            else
            {
                var dueno = GetDueno(idLogged);
                if (borrar.Dueno == dueno)
                    _tallerRepository.Delete(borrar);
                else
                    throw new NotFoundException($"Este taller no le pertenece");
            }

        }

        public List<TallerDTO> GetAll()
        {
            
            var talleres = _tallerRepository.GetAll();
            return _mapper.Map<List<TallerDTO>>(talleres);
        }

        public TallerDTO GetById(int id, int idLogged, string rolLogged)
        {
            var taller = _tallerRepository.GetById(id) ?? throw new NotFoundException($"No se encontró el ID ingresado: {id}");
            if (rolLogged == "SysAdmin")
            {
                return _mapper.Map<TallerDTO>(taller);
            }
            var dueno = GetDueno(idLogged);

            if (taller.Dueno == dueno)
                return _mapper.Map<TallerDTO>(taller);
            else
                throw new NotFoundException($"Este taller no le pertenece");
        }

        public void Update(int id, int duenoId, string rolDueno, TallerUpdateRequest tallerUpdateRequest)
        {
            var taller = _tallerRepository.GetById(id) ?? throw new NotFoundException($"No se encontró el ID ingresado: {id}");
            _mapper.Map(tallerUpdateRequest, taller);
            if (rolDueno == "SysAdmin")
            {
                _tallerRepository.Update(taller);
            }
            else
            {
                var dueno = GetDueno(duenoId);

                if (taller.Dueno == dueno)
                    _tallerRepository.Update(taller);
                else
                    throw new NotFoundException($"Este taller no le pertenece");
            }

        }

        public List<Taller> GetTallerConDuenos(int duenoId)
        {
            return _tallerRepository.GetTallerConDuenos(duenoId);
        }

        public Dueno GetDueno(int duenoId)
        {
            var dueno = _duenoRepository.GetByIdToken(duenoId);
            if (dueno == null)
            {
                throw new NotFoundException("Dueño no encontrado con el idToken proporcionado.");
            }
            return dueno;
        }
    }
}
