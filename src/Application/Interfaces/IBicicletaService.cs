﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models.Request;
using Application.Models;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IBicicletaService
    {
        void Delete(int id);
        List<BicicletaDTO> GetAll();
        BicicletaDTO GetById(int id);

        void Update(int id, BicicletaUpdateRequest bicicletaUpdateRequest);

        BicicletaDTO Create(BicicletaCreateRequest bicicletaCreateRequest);

        List<Bicicleta> GetBicicletasConClientes(int clienteId);
    }
}
