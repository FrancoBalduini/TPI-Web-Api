using Application.Models;
using Application.Models.Request;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ITallerService
    {
        void Delete(int id);
        List<TallerDTO> GetAll();
        TallerDTO GetById(int id);

        void Update(int id, TallerUpdateRequest tallerUpdateRequest);

        TallerDTO Create(TallerCreateRequest tallerCreateRequest);

        // Metodo especifico de taller para traer la lista de talleres con sus respectivos Duenos
        List<Taller> GetTallerConDuenos(int DuenoId); 


    }
}
