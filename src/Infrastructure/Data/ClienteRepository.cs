using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Data
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ApplicationContext _context;

        public ClienteRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Cliente GetClienteById(int id)
        {
            var cliente = _context.Clientes
                .Include(c => c.Mensajes)
                .Include(c => c.Bicicletas)
                .FirstOrDefault(c => c.Id == id);

            if (cliente == null)
            {
                throw new InvalidOperationException("Cliente no encontrado.");
            }

            if (cliente.Mensajes == null)
            {
                cliente.Mensajes = new List<Mensaje>();
            }

            if (cliente.Bicicletas == null)
            {
                cliente.Bicicletas = new List<Bicicleta>();
            }

            return cliente;
        }

        public IEnumerable<Cliente> GetAllClientes()
        {
            return _context.Clientes
                .Include(c => c.Mensajes)
                .Include(c => c.Bicicletas)
                .ToList();
        }

        public void CreateCliente(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
        }

        public void UpdateCliente(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            _context.SaveChanges();
        }

        public void DeleteCliente(int id)
        {
            var cliente = GetClienteById(id);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
                _context.SaveChanges();
            }
            else
            {
                
                throw new InvalidOperationException("Cliente no encontrado.");
            }
        }
    }
}
