using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.DTO
{
    public class BicicletaDTO
    {
        public int Id { get; set; }
        public string Marca { get; set; } = string.Empty;
        public string Modelo { get; set; } = string.Empty;

        public static BicicletaDTO FromEntity(Bicicleta bicicleta)
        {
            return new BicicletaDTO
            {
                Id = bicicleta.Id,
                Marca = bicicleta.Marca,
                Modelo = bicicleta.Modelo,
            };
        }

    }
}
