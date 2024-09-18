using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.DTO
{
    public class MensajeDTO
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }


        public int ClienteId { get; set; }
        public string Mensajes { get; set; } = string.Empty;
        public DateTime FechaDeCreacion { get; set; }
        public EstadoMensaje EstadoMensaje { get; set; }
        public static MensajeDTO FromEntity(Mensaje mensaje)
        {
            return new MensajeDTO
            {
                Id = mensaje.Id,
                ClienteId = mensaje.ClienteId,
                Mensajes = mensaje.Mensajes,
                FechaDeCreacion = mensaje.FechaDeCreacion,
                EstadoMensaje = mensaje.EstadoMensaje,
            };
        }
    }
}
