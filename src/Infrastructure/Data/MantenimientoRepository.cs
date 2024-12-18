﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Data
{
    public class MantenimientoRepository : BaseRepository<Mantenimiento>, IMantenimientoRepository
    {
        private readonly ApplicationContext _context;
        public MantenimientoRepository(ApplicationContext context) : base(context) 
        {
            _context = context;
        }
    }
}
