using ServicioTecnico.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioTecnico.Infrastructure.Interfaces
{
    public interface IPurchaseOrderLineRepositoryAsync
    {
        Task<IEnumerable<PurchaseOrderLine>> GetAllAsync();
    }
}
