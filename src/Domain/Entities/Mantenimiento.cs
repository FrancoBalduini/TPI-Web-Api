using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;

namespace Domain.Entities
{
    public class Mantenimiento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime FechaIngreso { get; set; } = DateTime.Now;
        public DateTime FechaSalida { get; set; } = DateTime.Now;
        public EstadoMantenimiento estadoMantenimiento { get; set; } = EstadoMantenimiento.Pendiente;
        public Bicicleta Bicicleta { get; set; }
        public int? BicicletaId { get; set; }
        public Taller Taller { get; set; }
        public int? TallerId { get;set; }

    }
}
