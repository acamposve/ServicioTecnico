using ServicioTecnico.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServicioTecnico.Infrastructure.Interfaces
{
    public interface ICustomerRepositoryAsync
    {
        Task<Customer> CreateAsync(Customer model);
        void DeleteAsync(Guid id);

        Task<IReadOnlyList<Customer>> GetAllAsync();
        Task<Customer> GetByIdAsync(Guid id);
    }
}
