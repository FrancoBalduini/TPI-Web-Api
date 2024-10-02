using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IClienteService
    {
        void Delete (int id);
        List<ClienteDTO> GetAll ();
        ClienteDTO GetById (int id);

        void Update(int id,ClienteUpdateRequest clienteUpdateRequest);

        ClienteDTO Create(ClienteCreateRequest clienteCreateRequest);
    }
}
