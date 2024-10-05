using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Request
{
    public class TallerUpdateRequest
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public string Direccion { get; set; } = string.Empty;
    }
}
