using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;

namespace Domain.Entities
{
    public class Mensaje
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public string Mensajes { get; set; } = string.Empty;
        public DateTime FechaDeCreacion { get; set; }
        public EstadoMensaje EstadoMensaje { get; set; }
        public Mensaje() { EstadoMensaje = EstadoMensaje.Pendiente; }


    }
}
