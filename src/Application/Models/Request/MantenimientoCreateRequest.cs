using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Request
{
    public class MantenimientoCreateRequest
    {
        public int BicicletaId { get; set; }
        public int TallerId { get; set; }
        public DateTime FechaIngreso {  get; set; }
        public DateTime FechaSalida { get; set; }
    }
}
