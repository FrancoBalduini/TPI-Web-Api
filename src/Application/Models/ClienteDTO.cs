using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class ClienteDTO 
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string NombreUser { get; set; } = string.Empty;

        public static ClienteDTO Create(Cliente cliente)
        {
            var dto = new ClienteDTO();
            dto.Id = cliente.Id;
            dto.Nombre = cliente.Nombre;
            dto.Apellido = cliente.Apellido;
            dto.Email = cliente.Email;
            dto.NombreUser = cliente.NombreUser;
            
            return dto;
        }
    }
}
