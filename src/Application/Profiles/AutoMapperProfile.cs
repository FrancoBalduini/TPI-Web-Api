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
                // Mapea la propiedad 'DuenoNombre' en el DTO, concatenando el nombre y apellido del Dueno
                // si existe, o asignando una cadena vacía si no hay Dueno asociado.
                .ForMember(dest => dest.DuenoNombre, opt => opt.MapFrom(taller => taller.Dueno != null ? $"{taller.Dueno.Nombre} {taller.Dueno.Apellido}" : string.Empty));
            
            CreateMap<ClienteCreateRequest, Cliente>();
            CreateMap<ClienteUpdateRequest, Cliente>();
            CreateMap<Cliente, ClienteDTO>();

            CreateMap<DuenoCreateRequest, Dueno>();
            CreateMap<DuenoUpdateRequest, Dueno>();
            CreateMap<Dueno, DuenoDTO>();

            CreateMap<Mantenimiento, MantenimientoDTO>();
            CreateMap<MantenimientoCreateRequest, Mantenimiento>();
            CreateMap<MantenimientoUpdateRequest, Mantenimiento>();


            CreateMap<BicicletaCreateRequest, Bicicleta>();
            CreateMap<BicicletaUpdateRequest, Bicicleta>();
            CreateMap<Bicicleta, BicicletaDTO>()
                .ForMember(dest => dest.ClienteNombre, opt => opt.MapFrom(bici => bici.Cliente != null ? $"{bici.Cliente.Nombre} {bici.Cliente.Apellido}" : string.Empty)); ;
        }
    }
}
