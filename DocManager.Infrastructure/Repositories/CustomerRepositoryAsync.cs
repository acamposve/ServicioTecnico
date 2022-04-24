using Dapper;
using Microsoft.Extensions.Options;
using ServicioTecnico.Domain.Entities;
using ServicioTecnico.Domain.Models.Customer;
using ServicioTecnico.Infrastructure.Context;
using ServicioTecnico.Infrastructure.Interfaces;
using ServicioTecnico.Infrastructure.Shared.Helpers;
using ServicioTecnico.Infrastructure.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioTecnico.Infrastructure.Repositories
{
    public class CustomerRepositoryAsync : ICustomerRepositoryAsync
    {
        private readonly DapperContext _context;
        private readonly ILoggerManager _logger;

        public CustomerRepositoryAsync(DapperContext context, ILoggerManager logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Customer> CreateAsync(Customer model)
        {
            var query = "INSERT INTO [dbo].[Customer] ([CustomerId],[Name],[Description],[Phone],[Email],[Address], [Address2]) VALUES (@CustomerId, @Name, @Description, @Phone, @Email, @Address, @Address2)";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", model.CustomerId, DbType.Guid);
            parameters.Add("Name", model.Name, DbType.String);
            parameters.Add("Description", model.Description, DbType.String);
            parameters.Add("Phone", model.Phone, DbType.String);
            parameters.Add("Email", model.Email, DbType.String);
            parameters.Add("Address", model.Address, DbType.String);
            parameters.Add("Address2", model.Address2, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                var id = await connection.QuerySingleAsync<Guid>(query, parameters);
                var createdUser = new Customer
                {
                    CustomerId = id,
                    Name = model.Name,
                    Description = model.Description,
                    Phone = model.Phone,
                    Email = model.Email,
                    Address = model.Address,
                    Address2 = model.Address2
                };
                return createdUser;
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            var query = "DELETE FROM Customer where CustomerId = @Id";
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { id });
            }
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            var query = "SELECT * FROM [dbo].[Customer]";
            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var users = await connection.QueryAsync<Customer>(query);
                    return users.ToList();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }

        public async Task<Customer> GetByIdAsync(Guid CustomerId)
        {
            var query = "SELECT * FROM Customer WHERE CustomerId = @CustomerId";
            using (var connection = _context.CreateConnection())
            {
                var user = await connection.QuerySingleOrDefaultAsync<Customer>(query, new { CustomerId });
                return user;
            }
        }

        public async Task UpdateAsync(Guid id, Customer model)
        {
            var query = "UPDATE [dbo].[Users] SET [FirstName] = @FirstName, [LastName] = @LastName, [Username] = @Username, [Role] = @Role, [Password] = @Password, [Email] = @Email WHERE id = @id";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", id, DbType.Guid);
            parameters.Add("Name", model.Name, DbType.String);
            parameters.Add("Description", model.Description, DbType.String);
            parameters.Add("Phone", model.Phone, DbType.String);
            parameters.Add("Email", model.Email, DbType.String);
            parameters.Add("Address", model.Address, DbType.String);
            parameters.Add("Address2", model.Address2, DbType.String);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

    }
}
