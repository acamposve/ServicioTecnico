using ServicioTecnico.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicioTecnico.Infrastructure.Interfaces
{
    public interface ICustomerRepositoryAsync
    {
        Task<Customer> CreateAsync(Customer model);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<Customer>> GetAllAsync();
        Task<Customer> GetByIdAsync(Guid id);
        Task UpdateAsync(Guid id, Customer model);
    }
}
