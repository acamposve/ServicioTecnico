using ServicioTecnico.Domain.Entities;
using ServicioTecnico.Domain.Models.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioTecnico.Application.Interfaces
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetAll();
        Task<Customer> GetById(Guid id);
        Task<Customer> Create(Customer model);
        Task Update(Guid id, Customer model);
        Task Delete(Guid id);
    }
}
