using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Models
{
    public class BicicletaDTO
    {
        public int Id { get; set; }
        public string Marca { get; set; } = string.Empty;
        public string Modelo { get; set; } = string.Empty;
        public string ClienteNombre { get; set; } = string.Empty;
        public static BicicletaDTO Create(Bicicleta bicicleta)

        {
            var dto = new BicicletaDTO();
            dto.Id = bicicleta.Id;
            dto.Marca = bicicleta.Marca;
            dto.Modelo = bicicleta.Modelo;
            // Si el taller tiene un dueño, devuelve su nombre completo; si no tiene dueño, devuelve una cadena vacía.
            dto.ClienteNombre = bicicleta.Cliente != null ? $"{bicicleta.Cliente.Nombre} {bicicleta.Cliente.Apellido}" : string.Empty;

            return dto;
        }
    }
}
