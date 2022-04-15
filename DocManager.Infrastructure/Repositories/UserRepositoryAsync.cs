using Dapper;
using ServicioTecnico.Domain.Entities;
using ServicioTecnico.Domain.Models.Users;
using ServicioTecnico.Infrastructure.Interfaces;
using ServicioTecnico.Infrastructure.Shared.Helpers;
using ServicioTecnico.Infrastructure.Shared.Interfaces;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace ServicioTecnico.Infrastructure.Repositories
{
    public class UserRepositoryAsync : IUserRepositoryAsync
    {
        private readonly AppSettings _appSettings;
        private readonly IDapper _dapper;
        private readonly ILoggerManager _logger;


        public UserRepositoryAsync(IOptions<AppSettings> appSettings, IDapper dapper, ILoggerManager logger)
        {
            _appSettings = appSettings.Value;
            _dapper = dapper;
            _logger = logger;
        }

        public async Task<User> Authenticate(string username, string password)
        {
            try
            {
                var user = await Task.FromResult(_dapper.Get<User>($"Select * from [Users] where username = '{username}' and password ='{password}'", null, commandType: CommandType.Text));

                _logger.LogInformation("Exito");
                return user;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message + " " + ex.InnerException);
                throw;
            }
        }

        public void DeleteAsync(int id)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("id", id);
            var updateArticle = Task.FromResult(_dapper.Update<int>("[dbo].[pa_delete_users]", dbPara, commandType: CommandType.StoredProcedure));
        }

        public async Task<IReadOnlyList<User>> GetAllAsync()
        {
            return await Task.FromResult(_dapper.GetAll<User>($"Select * from [Users]", null, commandType: CommandType.Text));
        }

        public async Task<User> GetByIdAsync(int id)
        {
            var result = await Task.FromResult(_dapper.Get<User>($"Select * from [Users] where Id = {id}", null, commandType: CommandType.Text));
            return result;
        }


        public async void UpdateAsync(int id, UpdateRequest model)
        {
            var user = await GetByIdAsync(id);

            var userBD = await Task.FromResult(_dapper.Get<User>($"Select * from [Users] where Username = '{model.Username}'", null, commandType: CommandType.Text));

            // validate
            if (model.Username != user.Username && userBD != null)
                throw new AppException("User with the email '" + model.Username + "' already exists");

            var dbPara = new DynamicParameters();
            dbPara.Add("id", user.Id);
            dbPara.Add("FirstName", model.FirstName, DbType.String);
            dbPara.Add("LastName", model.LastName, DbType.String);
            dbPara.Add("Username", model.Username, DbType.String);
            dbPara.Add("Role", model.Role, DbType.String);
            dbPara.Add("Password", model.Password, DbType.String);
            dbPara.Add("Email", model.Email, DbType.String);

            var updateArticle = Task.FromResult(_dapper.Update<int>("[dbo].[pa_update_users]", dbPara, commandType: CommandType.StoredProcedure));
        }


        public async Task<int>  CreateAsync(CreateRequest model)
        {
            var userBD = await Task.FromResult(_dapper.Get<User>($"Select * from [Users] where Username = '{model.Username}'", null, commandType: CommandType.Text));
            // validate
            if (userBD != null)
                throw new AppException("User with the email '" + model.Username + "' already exists");

            var dbparams = new DynamicParameters();
            dbparams.Add("FirstName", model.FirstName, DbType.String);
            dbparams.Add("LastName", model.LastName, DbType.String);
            dbparams.Add("Username", model.Username, DbType.String);
            dbparams.Add("Role", model.Role, DbType.String);
            dbparams.Add("Password", model.Password, DbType.String);
            dbparams.Add("Email", model.Email, DbType.String);
            var result = await Task.FromResult(_dapper.Insert<int>("[dbo].[pa_insert_users]", dbparams, commandType: CommandType.StoredProcedure));
            return 1;
        }
    }
}
