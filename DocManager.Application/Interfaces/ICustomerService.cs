using ServicioTecnico.Domain.Entities;
using ServicioTecnico.Domain.Models.Customer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServicioTecnico.Application.Interfaces
{
    public interface ICustomerService
    {
        Task<Customer> Create(CreateRequest model);
        Task<IReadOnlyList<Customer>> GetAllAsync();

        Task<Customer> GetByIdAsync(Guid id);
    }
}
