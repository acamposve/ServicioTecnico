using Dapper;
using ServicioTecnico.Domain.Models.ReceiptsAccounts;
using ServicioTecnico.Infrastructure.Interfaces;
using System.Data;
using System.Threading.Tasks;

namespace ServicioTecnico.Infrastructure.Repositories
{
    public class ReceiptsAccountsRepository : IReceiptsAccountsRepository
    {
        private readonly IDapper _dapper;
        public ReceiptsAccountsRepository(IDapper dapper)
        {
            _dapper = dapper;
        }

        public async Task<int> CreateUnique(CreateSingle model)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("EmbarquesId", int.Parse(model.embarqueid), DbType.Int32);
            dbparams.Add("AccountId", model.accountid, DbType.Int32);
            var result = await Task.FromResult(_dapper.Insert<int>("[dbo].[pa_insert_embarquesaccounts]", dbparams, commandType: CommandType.StoredProcedure));
            return 0;
        }



        public async Task<int> Create(CreateRequest model)
        {
            for (int i = 0; i < model.userid.Length; i++)
            {
                var dbparams = new DynamicParameters();
                dbparams.Add("EmbarquesId", model.embarqueid, DbType.Int32);
                dbparams.Add("AccountId", model.userid[i], DbType.Int32);
                var result = await Task.FromResult(_dapper.Insert<int>("[dbo].[pa_insert_embarquesaccounts]", dbparams, commandType: CommandType.StoredProcedure));
            }
            return 0;
        }

        public async Task<int> Delete(string embarqueid, int accountid)
        {
            int embarque = int.Parse(embarqueid);


            var dbparams = new DynamicParameters();
            dbparams.Add("EmbarquesId", embarque, DbType.Int32);
            dbparams.Add("AccountId", accountid, DbType.Int32);
            var result = await Task.FromResult(_dapper.Update<int>("[dbo].[pa_delete_embarques_accounts]", dbparams, commandType: CommandType.StoredProcedure));
            return 0;
        }
    }
}
