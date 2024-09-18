using Application.Models.Request;
using Application.Models.Requests;
using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Models.DTO;

namespace Application.Interfaces
{
    public interface IClienteService
    {
        ClienteDTO GetClienteById(int id);
        IEnumerable<Cliente> GetAllClientes();
        void CreateCliente(ClienteCreateRequest clienteCreateRequest);
        void UpdateCliente(ClienteUpdateRequest clienteUpdateRequest);
        void DeleteCliente(int id);
    }
}
