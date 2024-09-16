using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IClienteRepository
    {
        Cliente GetClienteById(int id);
        IEnumerable<Cliente> GetAllClientes();
        void CreateCliente(Cliente cliente);
        void UpdateCliente(Cliente cliente);
        void DeleteCliente(int id);
        
    }
}
