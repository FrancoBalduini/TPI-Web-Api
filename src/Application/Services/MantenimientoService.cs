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
using Domain.Enums;
using Domain.Exceptions;
using Domain.Interfaces;

namespace Application.Services
{
    public class MantenimientoService : IMantenimientoService
    {
        private readonly IMantenimientoRepository _repository;
        private readonly IMapper _mapper;
        private readonly IClienteRepository _clienteRepository;
        private readonly IDuenoRepository _duenoRepository;
        private readonly IBicicletaRepository _bicicletaRepository;
        private readonly ITallerRepository _tallerRepository;



        public MantenimientoService(IMantenimientoRepository repository, IBicicletaRepository BicicletaRepository, IMapper mapper, IDuenoRepository duenoRepository, IClienteRepository clienteRepository, ITallerRepository tallerRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _duenoRepository = duenoRepository;
            _clienteRepository = clienteRepository;
            _bicicletaRepository = BicicletaRepository;
            _tallerRepository = tallerRepository;
        }

        public MantenimientoDTO GetById(int id, int userId, string rolUser) 
        {
            var mantenimiento = _repository.GetById(id) ?? throw new NotFoundException($"No se encontro el id: {id}");
            if (rolUser == "SysAdmin")
            {
                return _mapper.Map<MantenimientoDTO>(mantenimiento);
            }
            else
            {
                if (rolUser == "Cliente")
                {
                    //Tenemos que traer la bici xq no se guarda en mantenimiento
                    var bicicletaComparar = GetBicicleta((int)mantenimiento.BicicletaId);
                    if (bicicletaComparar.ClienteId == userId)
                        return _mapper.Map<MantenimientoDTO>(mantenimiento);
                    else
                        throw new NotFoundException($"Esa mantenimiento no le pertenece");
                }
                else
                {
                    Dueno dueno = GetDueno(userId);
                    if (mantenimiento.Taller.Dueno == dueno)
                        return _mapper.Map<MantenimientoDTO>(mantenimiento);
                    else
                        throw new NotFoundException($"Esa mantenimiento no le pertenece");
                }
            }
            
        }

        public List<MantenimientoDTO> GetAll() 
        { 
            var ListaMantenimiento = _repository.GetAll();
            return _mapper.Map<List<MantenimientoDTO>>(ListaMantenimiento);
        }

        public MantenimientoDTO Create(MantenimientoCreateRequest request, int clienteId, string rolCliente)
        {
            var mantenimientoAgregar = _mapper.Map<Mantenimiento>(request);

            if (rolCliente == "SysAdmin")
            {
                _repository.Add(mantenimientoAgregar);
                return _mapper.Map<MantenimientoDTO>(mantenimientoAgregar);
            }
            else
            {

                //Cliente cliente = GetCliente(clienteId);
                var bicicleta = _bicicletaRepository.GetById(request.BicicletaId) ?? throw new NotFoundException($"No se encontro la bicicleta con el id : {request.BicicletaId}");
                mantenimientoAgregar.Bicicleta = bicicleta;
                if (mantenimientoAgregar.Bicicleta.ClienteId == clienteId)
                {

                    var biciUpdatear = _bicicletaRepository.GetById(request.BicicletaId);
                    biciUpdatear.Mantenimientos.Add(mantenimientoAgregar);
                    _repository.Add(mantenimientoAgregar);
                    _bicicletaRepository.Update(biciUpdatear);
                    _repository.SaveChanges();
                    return _mapper.Map<MantenimientoDTO>(mantenimientoAgregar);
                }                   
                else
                    throw new NotFoundException($"Esa mantenimiento no le pertenece");
                
            }
        }

        public void Update(int id, int loggedId, string rolLogged, MantenimientoUpdateRequest request)
        {
            var mantenimientoUpdatear = _repository.GetById(id) ?? throw new NotFoundException($"No se encontro el id: {id}");

            if (rolLogged == "SysAdmin")
            {
                _mapper.Map(request, mantenimientoUpdatear);
                _repository.Update(mantenimientoUpdatear);
                return;
            }
            else if (rolLogged == "Cliente")
            {
                if (request.estadoMantenimiento == EstadoMantenimiento.Cancelado)
                {
                    _mapper.Map(request, mantenimientoUpdatear);
                    _repository.Update(mantenimientoUpdatear);
                    return;
                }
                else throw new NotFoundException($"No puede cambiar el estado del mantenimiento a Aceptado/Completado/Pendiente");
            }
            else
            {
                if (mantenimientoUpdatear.Taller.DuenoId == loggedId)
                {
                    _mapper.Map(request, mantenimientoUpdatear);
                    _repository.Update(mantenimientoUpdatear);
                    return;
                }
                else throw new NotFoundException($"Los mantenimientos no pertenecen a alguno de sus talleres");
            }   
        }

        public void Delete(int id)
        {
            var borrar = _repository.GetById(id) ?? throw new NotFoundException($"No se encontro el id: {id}");
            _repository.Delete(borrar);
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

        public Dueno GetDueno(int duenoId)
        {
            var dueno = _duenoRepository.GetByIdToken(duenoId);
            if (dueno == null)
            {
                throw new NotFoundException("Dueño no encontrado con el idToken proporcionado.");
            }
            return dueno;
        }
        public Bicicleta GetBicicleta(int clienteId)
        {
            var bicicleta = _bicicletaRepository.GetById(clienteId);
            if (bicicleta == null)
            {
                throw new NotFoundException("Dueño no encontrado con el idToken proporcionado.");
            }
            return bicicleta;
        }
    }
}
