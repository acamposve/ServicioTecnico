using ServicioTecnico.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioTecnico.Infrastructure.Interfaces
{
    public interface IVendorRepositoryAsync
    {
        Task<Vendor> CreateAsync(Vendor model);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<Vendor>> GetAllAsync();
        Task<Vendor> GetByIdAsync(Guid id);
        Task UpdateAsync(Guid id, Vendor model);
    }
}
