using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models.Request;
using Application.Models;
using Domain.Entities;
using Domain.Enums;

namespace Application.Interfaces
{
    public interface IBicicletaService
    {
        void Delete(int id, int idLogged, string rolLogged);
        List<BicicletaDTO> GetAll();
        BicicletaDTO GetById(int id, int clienteId,string rolCliente);

        void Update(int id, int clienteId,string rolCliente, BicicletaUpdateRequest bicicletaUpdateRequest);

        BicicletaDTO Create(BicicletaCreateRequest bicicletaCreateRequest, int clienteIdToken);

        List<BicicletaDTO> GetBicicletasConCliente(int clienteId);
    }
}
