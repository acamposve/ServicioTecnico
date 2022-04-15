using Dapper;
using ServicioTecnico.Domain.Entities;
using ServicioTecnico.Domain.Models.ReceiptsStatus;
using ServicioTecnico.Infrastructure.Interfaces;
using ServicioTecnico.Infrastructure.Shared.Helpers;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace ServicioTecnico.Infrastructure.Repositories
{
    public class ReceiptStatusRepository : IReceiptStatusRepository
    {
        private readonly IDapper _dapper;

        public ReceiptStatusRepository(IDapper dapper)
        {
            _dapper = dapper;
        }

        public async Task<IEnumerable<ReceiptStatus>> GetAll()
        {
            return await Task.FromResult(_dapper.GetAll<ReceiptStatus>($"Select * from [ReceiptStatus]", null, commandType: CommandType.Text));
        }
        public async Task<ReceiptStatus> GetById(int id)
        {
            var result = await Task.FromResult(_dapper.Get<ReceiptStatus>($"Select * from [ReceiptStatus] where Id = {id}", null, commandType: CommandType.Text));
            return result;
        }
        public async void Create(CreateRequest model)
        {

            var userBD = await Task.FromResult(_dapper.Get<ReceiptStatus>($"Select * from [ReceiptStatus] where status = '{model.status}'", null, commandType: CommandType.Text));




            // validate
            if (userBD != null)
                throw new AppException("User with the email '" + model.status + "' already exists");



            var dbparams = new DynamicParameters();
            dbparams.Add("status", model.status, DbType.String);

            var result = await Task.FromResult(_dapper.Insert<int>("[dbo].[pa_insert_receiptstatus]"
                    , dbparams,
                    commandType: CommandType.StoredProcedure));

        }
        public async void Update(int id, UpdateRequest model)
        {
            var user = await GetById(id);

            var userBD = await Task.FromResult(_dapper.Get<ReceiptStatus>($"Select * from [ReceiptStatus] where status = '{model.status}'", null, commandType: CommandType.Text));

            // validate
            if (model.status != user.status && userBD != null)
                throw new AppException("User with the email '" + model.status + "' already exists");

            var dbparams = new DynamicParameters();
            dbparams.Add("id", user.id);
            dbparams.Add("status", model.status, DbType.String);


            var updateArticle = Task.FromResult(_dapper.Update<int>("[dbo].[pa_update_receiptstatus]",
                            dbparams,
                            commandType: CommandType.StoredProcedure));



        }
        public void Delete(int id)
        {

            var dbPara = new DynamicParameters();
            dbPara.Add("id", id);

            var updateArticle = Task.FromResult(_dapper.Update<int>("[dbo].[pa_delete_receiptstatus]",
                            dbPara,
                            commandType: CommandType.StoredProcedure));


        }
    }
}
