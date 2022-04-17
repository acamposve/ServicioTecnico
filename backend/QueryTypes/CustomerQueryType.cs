using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using ServicioTecnico.Application.Interfaces;
using ServicioTecnico.Domain.Entities;
using System.Linq;
using WebApi.DataContext;

namespace WebApi.QueryTypes
{
    [ExtendObjectType(Name = "TecnicService")]
    public class CustomerQueryType
    {
        [UseProjection]
        [UseFiltering]
        public IQueryable<Customer> GetCustomers([Service] ICustomerService _customerService)
        {
            return _customerService.GetAllAsync();
        }
    }
}
