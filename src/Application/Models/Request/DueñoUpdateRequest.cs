using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Request
{
    public class DueñoUpdateRequest
    {
        private int id { get; set; } 
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        public string Contrasenia { get; set; } = string.Empty;
        public string NombreUser { get; set; } = string.Empty;
    }
}
