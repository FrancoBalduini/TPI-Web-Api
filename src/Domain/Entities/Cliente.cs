﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Cliente : Usuario
    {
        public ICollection<Bicicleta> Bicicletas { get; set; } = new List<Bicicleta>();
    }
}
