using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using Application.Models.Request;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IMantenimientoService
    {
        MantenimientoDTO? GetById(int id,int clienteId,string rolCliente);
        List<MantenimientoDTO> GetAll();
        MantenimientoDTO Create(MantenimientoCreateRequest request, int clienteId, string rolCliente);
        void Update(int id, int loggedId, string rolLogged, MantenimientoUpdateRequest request);
        void Delete(int id);
    }
}
