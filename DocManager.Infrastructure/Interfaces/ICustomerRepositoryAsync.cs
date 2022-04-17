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
        void DeleteAsync(Guid id);

        IQueryable<Customer> GetAllAsync();
        Task<Customer> GetByIdAsync(Guid id);
    }
}
