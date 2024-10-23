using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Enums;

namespace Application.Models
{
    public class MantenimientoDTO
    {
        public int Id { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaSalida { get; set; }
        public EstadoMantenimiento estadoMantenimiento { get; set; } = EstadoMantenimiento.Pendiente;

        public static MantenimientoDTO Create(Mantenimiento mantenimiento)
        {
            var dto = new MantenimientoDTO
            {
                Id = mantenimiento.Id,
                estadoMantenimiento = mantenimiento.estadoMantenimiento,
                FechaIngreso = mantenimiento.FechaIngreso,
                FechaSalida = mantenimiento.FechaSalida
            };
            return dto;
        }
    }
}
