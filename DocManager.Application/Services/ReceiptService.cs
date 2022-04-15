using ServicioTecnico.Application.Interfaces;
using ServicioTecnico.Domain.Entities;
using ServicioTecnico.Domain.Models.Receipts;
using ServicioTecnico.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServicioTecnico.Application.Services
{
    public class ReceiptService : IReceiptService
    {
        private readonly IReceiptRepository _repository;
        public ReceiptService(IReceiptRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<Receipt>> GetAll()
        {
            return await _repository.GetAll();
        }
        public async Task<IEnumerable<ReceiptsByAccount>> GetAllByAccount(int id)
        {
            return await _repository.GetAllByAccount(id);
        }
        public async Task<Receipt> GetById(int id)
        {
            return await _repository.GetById(id);
        }
        public async Task<Receipt> GetByReferencia(string referencia)
        {
            return await _repository.GetByReferencia(referencia);
        }
        public async Task<int> Create(CreateRequest model)
        {
            return await _repository.Create(model);
        }
        public void Update(int id, UpdateRequest model)
        {
            _repository.Update(id, model);
        }
        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public async Task<IEnumerable<FilesByReceipt>> GetFilesByReceipt(int id)
        {
            return await _repository.GetFilesByReceipt(id);
        }

        public async Task<IEnumerable<AccountByReceipt>> GetAccountByReceipt(int id)
        {
            return await _repository.GetAccountByReceipt(id);
        }
        public async Task<IEnumerable<AccountByReceipt>> GetAccountNotInReceipt(int id)
        {
            return await _repository.GetAccountNotInReceipt(id);
        }
    }
}
