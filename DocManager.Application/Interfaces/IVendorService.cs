using ServicioTecnico.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioTecnico.Application.Interfaces
{
    public interface IVendorService
    {
        Task<IEnumerable<Vendor>> GetAll();
        Task<Vendor> GetById(Guid id);
        Task<Vendor> Create(Vendor model);
        Task Update(Guid id, Vendor model);
        Task Delete(Guid id);
    }
}
