using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Dueño : Usuario
    {
        public ICollection<Taller> Talleres { get; set; } = new List<Taller>();
    }
}
