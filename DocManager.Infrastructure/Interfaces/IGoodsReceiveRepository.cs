using ServicioTecnico.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioTecnico.Infrastructure.Interfaces
{
    public interface IGoodsReceiveRepository
    {
        Task<GoodsReceive> CreateAsync(GoodsReceive model);

        Task<IEnumerable<GoodsReceive>> GetAllAsync();
    }
}
