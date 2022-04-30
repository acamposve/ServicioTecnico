using ServicioTecnico.Domain.Entities;
using ServicioTecnico.Domain.Models.GoodsReceive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioTecnico.Application.Interfaces
{
    public interface IGoodsReceiveService
    {
        Task<GoodsReceive> Create(CreateRequest model);
    }
}
