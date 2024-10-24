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
    public interface IDuenoService
    {
        void Delete(int id);
        List<DuenoDTO> GetAll();
        DuenoDTO GetById(int id);

        void Update(int id, DuenoUpdateRequest DuenoUpdateRequest);

        DuenoDTO Create(DuenoCreateRequest DuenoCreateRequest);

        
    }
}
