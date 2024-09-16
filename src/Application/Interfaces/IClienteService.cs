using Application.Models.Request;
using Application.Models.Requests;
using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IClienteService
    {
        Cliente GetClienteById(int id);
        IEnumerable<Cliente> GetAllClientes();
        void CreateCliente(ClienteCreateRequest clienteCreateRequest);
        void UpdateCliente(ClienteUpdateRequest clienteUpdateRequest);
        void DeleteCliente(int id);
    }
}
