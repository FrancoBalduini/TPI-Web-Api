using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class TallerDTO
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public string Direccion { get; set; } = string.Empty;

        public string DueñoNombre { get; set; } = string.Empty;

        public static TallerDTO Create(Taller taller)

        {
            var dto = new TallerDTO();
            dto.Id = taller.Id;
            dto.Nombre = taller.Nombre;
            dto.Direccion = taller.Direccion;
            // Si el taller tiene un dueño, devuelve su nombre completo; si no tiene dueño, devuelve una cadena vacía.
            dto.DueñoNombre = taller.Dueño != null ? $"{taller.Dueño.Nombre} {taller.Dueño.Apellido}" : string.Empty;

            return dto;
        }

        public static List<TallerDTO> CreateList(IEnumerable<Taller> talleres)
        {

            List<TallerDTO> listDto = new List<TallerDTO>();  // Crea una lista vacía para almacenar los objetos TallerDTO convertidos.
            foreach (var taller in talleres) // Recorre cada objeto Taller en la colección de talleres.
            {
                listDto.Add(Create(taller)); // Convierte el objeto Taller a TallerDTO y lo agrega a la lista.
            }

            return listDto; // Devuelve la lista completa de TallerDTO.
        }
    }
}
