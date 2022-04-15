using ServicioTecnico.Application.Interfaces;
using ServicioTecnico.Domain.Models.ReceiptsAccounts;
using ServicioTecnico.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServicioTecnico.Application.Services
{
    public class ReceiptsAccountsService : IReceiptsAccountsService
    {
        private readonly IReceiptsAccountsRepository _repository;
        public ReceiptsAccountsService(IReceiptsAccountsRepository repository)
        {
            _repository= repository;
        }



        public async Task<int> CreateUnique(CreateSingle model)
        {
            return await _repository.CreateUnique(model);
        }



        public async Task<int> Create(CreateRequest model)
        {
            return await _repository.Create(model);
        }

        public async Task<int> Delete(string embarqueid, int accountid)
        {
            await _repository.Delete(embarqueid, accountid);
            return 0;
        }
    }
}
