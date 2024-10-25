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

        // Metodo especifico de taller para traer la lista de talleres con sus respectivos Duenos
        public List<Taller> GetTallerConDuenos(int DuenoId)
        {
            return _context.Talleres
                .Where(t => t.DuenoId == DuenoId)
                .ToList();
        }

    }
}
