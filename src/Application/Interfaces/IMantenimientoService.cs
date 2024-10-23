using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using Application.Models.Request;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IMantenimientoService
    {
        MantenimientoDTO? GetById(int id);
        List<MantenimientoDTO> GetAll();
        MantenimientoDTO Create(MantenimientoCreateRequest request);
        void Update(int id, MantenimientoUpdateRequest request);
        void Delete(int id);
    }
}
