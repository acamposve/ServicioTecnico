using ServicioTecnico.Domain.Models.ReceiptsAccounts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServicioTecnico.Infrastructure.Interfaces
{
    public interface IReceiptsAccountsRepository
    {
        Task<int> CreateUnique(CreateSingle model);
        Task<int> Create(CreateRequest model);
        Task<int> Delete(string embarqueid, int accountid);
    }
}
