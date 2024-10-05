using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Taller
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; } = string.Empty;

        [Required]

        public string Direccion { get; set; } = string.Empty;
        public Dueño Dueño { get; set; } // Propiedad para la navegación para poder acceder a la entidad Dueño desde la instancia de Taller
        public int? DueñoId { get; set; }
        public ICollection<Mantenimiento> Mantenimientos { get; set; } = new List<Mantenimiento>();

    }
}
