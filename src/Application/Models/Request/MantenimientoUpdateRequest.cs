using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;

namespace Application.Models.Request
{
    public class MantenimientoUpdateRequest
    {
        private int Id { get; set; }
        private DateTime FechaIngreso { get; set; }
        public DateTime FechaSalida { get; set; } 
        public EstadoMantenimiento estadoMantenimiento { get; set; }
    }
}
