using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class BicicletaRepository : BaseRepository<Bicicleta>, IBicicletaRepository
    {
        private readonly ApplicationContext _context;
        public BicicletaRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }
        public List<Bicicleta> GetBicicletasConClientes(int clienteId)
        {
            return _context.Bicicletas
                .Include(m => m.Mantenimientos)
                .Where(t => t.ClienteId == clienteId)
                .ToList();
        }
    }
}
