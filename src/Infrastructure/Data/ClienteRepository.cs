using Application.Interfaces;
using Domain.Entities;
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

    }


}
