using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models.Request;
using Application.Models;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IDueñoService
    {
        void Delete(int id);
        List<DueñoDTO> GetAll();
        DueñoDTO GetById(int id);

        void Update(int id, DueñoUpdateRequest dueñoUpdateRequest);

        DueñoDTO Create(DueñoCreateRequest dueñoCreateRequest);

        
    }
}
