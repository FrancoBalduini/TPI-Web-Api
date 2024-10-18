using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Models
{
    public class DueñoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string NombreUser { get; set; } = string.Empty;

        public static DueñoDTO Create(Dueño dueño)
        {
            var dto = new DueñoDTO();
            dto.Id = dueño.Id;
            dto.Nombre = dueño.Nombre;
            dto.Apellido = dueño.Apellido;
            dto.Email = dueño.Email;
            dto.NombreUser = dueño.NombreUser;

            return dto;
        }

    }
}
