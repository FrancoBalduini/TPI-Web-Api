using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain.Interfaces;

namespace Infrastructure.Data
{
    public class TallerRepository : BaseRepository<Taller>, ITallerRepository
    {
        private readonly ApplicationContext _context;
        public TallerRepository(ApplicationContext context) : base(context)
        {
            _context = context; 
        }

        // Metodo especifico de taller para traer la lista de talleres con sus respectivos Dueños
        public List<Taller> GetTallerConDueños(int dueñoId)
        {
            return _context.Talleres
                .Include(t => t.Dueño)
                .Where(t => t.DueñoId == dueñoId)
                .ToList();
        }

    }
}
