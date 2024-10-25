using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Data
{
    public class DuenoRepository : BaseRepository<Dueno>, IDuenoRepository
    {
        private readonly ApplicationContext _context;
        public DuenoRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        public Dueno GetByIdToken(int idToken)
        {
            return _context.Duenos.FirstOrDefault(d => d.Id == idToken);
        }
    }
}
