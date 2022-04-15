using ServicioTecnico.Domain.Entities;
using ServicioTecnico.Domain.Models.Receipts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServicioTecnico.Infrastructure.Interfaces
{
    public interface IReceiptRepository
    {
        Task<IEnumerable<Receipt>> GetAll();
        Task<IEnumerable<ReceiptsByAccount>> GetAllByAccount(int id);
        Task<Receipt> GetById(int id);
        Task<Receipt> GetByReferencia(string referencia);
        Task<int> Create(CreateRequest model);
        void Update(int id, UpdateRequest model);
        void Delete(int id);
        Task<IEnumerable<FilesByReceipt>> GetFilesByReceipt(int id);
        Task<IEnumerable<AccountByReceipt>> GetAccountByReceipt(int id);
        Task<IEnumerable<AccountByReceipt>> GetAccountNotInReceipt(int id);
    }
}
