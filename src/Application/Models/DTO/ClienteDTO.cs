using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Application.Models.Requests;

namespace Application.Models.DTO
{
    public class ClienteDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Contrasenia { get; set; } = string.Empty;
        public string NombreUser { get; set; } = string.Empty;
        public ICollection<MensajeDTO> Mensajes { get; set; } = new List<MensajeDTO>();
        public ICollection<BicicletaDTO> Bicicletas { get; set; } = new List<BicicletaDTO>();
        public static ClienteDTO FromEntity(Cliente cliente)
        {
            return new ClienteDTO
            {
                Id = cliente.Id,
                Nombre = cliente.Nombre,
                Apellido = cliente.Apellido,
                Email = cliente.Email,
                Contrasenia = cliente.Contrasenia,
                NombreUser = cliente.NombreUser,
                Mensajes = cliente.Mensajes?.Select(m => MensajeDTO.FromEntity(m)).ToList(),
                Bicicletas = cliente.Bicicletas?.Select(m => BicicletaDTO.FromEntity(m)).ToList()
            };
        }
    }
}
