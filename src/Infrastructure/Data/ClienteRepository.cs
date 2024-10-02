using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly List<Cliente> _clienteList = new List<Cliente>();

        public Cliente GetById(int id) 
        {

            return _clienteList.FirstOrDefault(c => c.Id == id)?? throw new NotFoundException;
            
        }

        public List<Cliente> GetAll()
        {
            return _clienteList;
        }

        public void Create(Cliente cliente) 
        {
            _clienteList.Add(cliente);
        }

        public void Update(Cliente cliente)
        {
            var cualquiercosa
        }

        public void Delete(Cliente cliente) 
        { 
            _clienteList.Remove(cliente);
        }


}
