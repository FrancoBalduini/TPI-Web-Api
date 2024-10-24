using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        private readonly ApplicationContext _context;
        public ClienteRepository(ApplicationContext context) : base(context) 
        {
            _context = context;
        }

        public Cliente GetByIdToken(int idToken)
        {
            return _context.Clientes.FirstOrDefault(c => c.Id == idToken);
        }
    }


}
