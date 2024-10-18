using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IBicicletaRepository : IBaseRepository<Bicicleta>
    {
        List<Bicicleta> GetBicicletasConClientes(int clienteId);
    }
}
