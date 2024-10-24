using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Models
{
    public class DuenoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string NombreUser { get; set; } = string.Empty;

        public static DuenoDTO Create(Dueno Dueno)
        {
            var dto = new DuenoDTO();
            dto.Id = Dueno.Id;
            dto.Nombre = Dueno.Nombre;
            dto.Apellido = Dueno.Apellido;
            dto.Email = Dueno.Email;
            dto.NombreUser = Dueno.NombreUser;

            return dto;
        }

    }
}
