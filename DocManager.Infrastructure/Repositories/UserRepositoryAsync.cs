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
using ServicioTecnico.Infrastructure.Context;
using System.Linq;

namespace ServicioTecnico.Infrastructure.Repositories
{
    public class UserRepositoryAsync : IUserRepositoryAsync
    {
        private readonly DapperContext _context;
        private readonly ILoggerManager _logger;


        public UserRepositoryAsync(DapperContext context, ILoggerManager logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<User> Authenticate(string username, string password)
        {
            try
            {
                var query = $"Select * from [Users] where username = '{username}' and password ='{password}'";

                using (var connection = _context.CreateConnection())
                {
                    var user = await connection.QuerySingleOrDefaultAsync<User>(query);
                    _logger.LogInformation("Exito");
                    return user;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message + " " + ex.InnerException);
                throw;
            }
        }

        public async Task DeleteUserAsync(int id)
        {
            var query = "DELETE FROM Users WHERE Id = @Id";
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { id });
            }
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            var query = "SELECT [id],[FirstName],[LastName],[Username],[Role],[Password],[Email] FROM [dbo].[Users]";
            using (var connection = _context.CreateConnection())
            {
                var users = await connection.QueryAsync<User>(query);
                return users.ToList();
            }
        }

        public async Task<User> GetByIdAsync(int id)
        {
            var query = "SELECT * FROM Users WHERE id = @Id";
            using (var connection = _context.CreateConnection())
            {
                var user = await connection.QuerySingleOrDefaultAsync<User>(query, new { id });
                return user;
            }
        }


        public async Task UpdateAsync(int id, UpdateRequest model)
        {
            var query = "UPDATE [dbo].[Users] SET [FirstName] = @FirstName, [LastName] = @LastName, [Username] = @Username, [Role] = @Role, [Password] = @Password, [Email] = @Email WHERE id = @id";
            var parameters = new DynamicParameters();
            parameters.Add("id", id, DbType.Int32);
            parameters.Add("FirstName", model.FirstName, DbType.String);
            parameters.Add("LastName", model.LastName, DbType.String);
            parameters.Add("Username", model.Username, DbType.String);
            parameters.Add("Role", model.Role, DbType.String);
            parameters.Add("Password", model.Password, DbType.String);
            parameters.Add("Email", model.Email, DbType.String);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }


        public async Task<User> CreateAsync(CreateRequest model)
        {
            var query = "INSERT INTO [dbo].[Users] ([FirstName],[LastName],[Username],[Role], [Password], [Email]) VALUES (@FirstName, @LastName, @Username, @Role, @Password, @Email)" +
                    "SELECT CAST(SCOPE_IDENTITY() as int)";
            var parameters = new DynamicParameters();
            parameters.Add("FirstName", model.FirstName, DbType.String);
            parameters.Add("LastName", model.LastName, DbType.String);
            parameters.Add("Username", model.Username, DbType.String);
            parameters.Add("Role", model.Role, DbType.String);
            parameters.Add("Password", model.Password, DbType.String);
            parameters.Add("Email", model.Email, DbType.String);
            using (var connection = _context.CreateConnection())
            {
                var id = await connection.QuerySingleAsync<int>(query, parameters);
                var createdUser = new User
                {
                    Id = id,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Username = model.Username,
                    Role = model.Role,
                    Email = model.Email
                };
                return createdUser;
            }
        }
    }
}
