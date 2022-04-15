using ServicioTecnico.Domain.Entities;
using ServicioTecnico.Domain.Models.ReceiptsStatus;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServicioTecnico.Application.Interfaces
{
    public interface IReceiptStatusService
    {
        Task<IEnumerable<ReceiptStatus>> GetAll();
        Task<ReceiptStatus> GetById(int id);
        void Create(CreateRequest model);
        void Update(int id, UpdateRequest model);
        void Delete(int id);
    }
}
