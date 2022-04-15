using ServicioTecnico.Application.Interfaces;
using ServicioTecnico.Domain.Entities;
using ServicioTecnico.Domain.Models.ReceiptsStatus;
using ServicioTecnico.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServicioTecnico.Application.Services
{
    public class ReceiptStatusService : IReceiptStatusService
    {
        private readonly IReceiptStatusRepository _repository;
        public ReceiptStatusService(IReceiptStatusRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ReceiptStatus>> GetAll()
        {
            return await _repository.GetAll();
        }
        public async Task<ReceiptStatus> GetById(int id)
        {
            return await _repository.GetById(id); 
        }
        public void Create(CreateRequest model)
        {
            _repository.Create(model);
        }
        public void Update(int id, UpdateRequest model)
        {
            _repository.Update(id, model);
        }
        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
