using Dapper;
using Microsoft.Extensions.Options;
using ServicioTecnico.Domain.Entities;
using ServicioTecnico.Domain.Models.Customer;
using ServicioTecnico.Infrastructure.Interfaces;
using ServicioTecnico.Infrastructure.Shared.Helpers;
using ServicioTecnico.Infrastructure.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace ServicioTecnico.Infrastructure.Repositories
{
    public class CustomerRepositoryAsync : ICustomerRepositoryAsync
    {
        private readonly AppSettings _appSettings;
        private readonly IDapper _dapper;
        private readonly ILoggerManager _logger;

        public CustomerRepositoryAsync(IOptions<AppSettings> appSettings, IDapper dapper, ILoggerManager logger)
        {
            _appSettings = appSettings.Value;
            _dapper = dapper;
            _logger = logger;
        }

        public async Task<Customer> CreateAsync(Customer model)
        {
            var sql = "INSERT INTO [dbo].[Customer] ([CustomerId],[Name],[Description],[Phone],[Email],[Address], [Address2]) VALUES (@CustomerId, @Name, @Description, @Phone, @Email, @Address, @Address2)";
            var dbparams = new DynamicParameters();
            dbparams.Add("CustomerId", model.CustomerId, DbType.Guid);
            dbparams.Add("Name", model.Name, DbType.String);
            dbparams.Add("Description", model.Description, DbType.String);
            dbparams.Add("Phone", model.Phone, DbType.String);
            dbparams.Add("Email", model.Email, DbType.String);
            dbparams.Add("Address", model.Address, DbType.String);
            dbparams.Add("Address2", model.Address2, DbType.String);

            return await Task.FromResult(_dapper.Insert<Customer>(sql, dbparams, CommandType.Text));
        }

        public void DeleteAsync(Guid id)
        {
            var sql = "delete from Customers where CustomerId = @id";
            var dbPara = new DynamicParameters();
            dbPara.Add("id", id);
            var updateArticle = Task.FromResult(_dapper.Delete(sql, dbPara, commandType: CommandType.Text));
        }

        public async Task<IReadOnlyList<Customer>> GetAllAsync()
        {
            return await Task.FromResult(_dapper.GetAll<Customer>($"Select * from [Customer]", null, commandType: CommandType.Text));
        }

        public async Task<Customer> GetByIdAsync(Guid id)
        {
            var result = await Task.FromResult(_dapper.Get<Customer>($"Select * from [Customer] where Id = {id}", null, commandType: CommandType.Text));
            return result;
        }


        
    }
}
