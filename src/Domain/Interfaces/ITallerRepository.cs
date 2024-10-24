using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ITallerRepository : IBaseRepository<Taller>
    {
        // Metodo especifico de taller para traer la lista de talleres con sus respectivos Duenos
        List<Taller> GetTallerConDuenos(int DuenoId);
    }
}
