using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models.Request;
using Application.Models;
using AutoMapper;
using Domain.Entities;

namespace Application.Profiles
{
    public class AutoMapperProfile : Profile

    {
        public AutoMapperProfile()
        {
            // Definición del mapeo entre los DTOs y las entidades
            CreateMap<TallerCreateRequest, Taller>();
            CreateMap<TallerUpdateRequest, Taller>();
            CreateMap<Taller, TallerDTO>()
                // Mapea la propiedad 'DueñoNombre' en el DTO, concatenando el nombre y apellido del dueño
                // si existe, o asignando una cadena vacía si no hay dueño asociado.
                .ForMember(dest => dest.DueñoNombre, opt => opt.MapFrom(src => src.Dueño != null ? $"{src.Dueño.Nombre} {src.Dueño.Apellido}" : string.Empty));
            
            CreateMap<ClienteCreateRequest, Cliente>();
            CreateMap<ClienteUpdateRequest, Cliente>();
            CreateMap<Cliente, ClienteDTO>();

            CreateMap<DueñoCreateRequest, Dueño>();
            CreateMap<DueñoUpdateRequest, Dueño>();
            CreateMap<Dueño, DueñoDTO>();

            CreateMap<Mantenimiento, MantenimientoDTO>();
            CreateMap<MantenimientoCreateRequest, Mantenimiento>();
            CreateMap<MantenimientoUpdateRequest, Mantenimiento>();


            CreateMap<BicicletaCreateRequest, Bicicleta>();
            CreateMap<BicicletaUpdateRequest, Bicicleta>();
            CreateMap<Bicicleta, BicicletaDTO>()
                .ForMember(dest => dest.ClienteNombre, opt => opt.MapFrom(src => src.Cliente != null ? $"{src.Cliente.Nombre} {src.Cliente.Apellido}" : string.Empty)); ;
        }
    }
}
