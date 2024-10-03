using Application.Models;
using Application.Models.Request;
using Domain.Entities;
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
        List<Cliente> GetAll ();
        Cliente GetById (int id);

        void Update(int id, Cliente cliente);

        Cliente Create(Cliente cliente);
    }
}
