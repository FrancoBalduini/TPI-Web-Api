﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Request
{
    public class MantenimientoCreateRequest
    {
        public DateTime FechaIngreso {  get; set; }
        public DateTime FechaSalida { get; set; }
    }
}
