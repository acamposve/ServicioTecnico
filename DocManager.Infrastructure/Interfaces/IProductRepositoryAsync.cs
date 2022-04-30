using ServicioTecnico.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioTecnico.Infrastructure.Interfaces
{
    public interface IProductRepositoryAsync
    {
        Task<Product> CreateAsync(Product model);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(Guid id);
        Task UpdateAsync(Guid id, Product model);
    }
}
