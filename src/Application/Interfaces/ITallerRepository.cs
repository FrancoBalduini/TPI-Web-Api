using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ITallerRepository : IBaseRepository<Taller>
    {
        // Metodo especifico de taller para traer la lista de talleres con sus respectivos Dueños
        List<Taller> GetTallerConDueños(int dueñoId);
    }
}
