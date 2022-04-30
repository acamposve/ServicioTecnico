using Dapper;
using ServicioTecnico.Domain.Entities;
using ServicioTecnico.Infrastructure.Context;
using ServicioTecnico.Infrastructure.Interfaces;
using ServicioTecnico.Infrastructure.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioTecnico.Infrastructure.Repositories
{
    public class VendorRepositoryAsync : IVendorRepositoryAsync
    {
        private readonly DapperContext _context;
        private readonly ILoggerManager _logger;
        public VendorRepositoryAsync(DapperContext context, ILoggerManager logger)
        {
            _context = context;
            _logger = logger;
        }


        public async Task<Vendor> CreateAsync(Vendor model)
        {
            var query = "INSERT INTO [dbo].[Vendor] ([VendorId],[Name],[Description],[Phone],[Email],[Address], [Address2]) VALUES (@CustomerId, @Name, @Description, @Phone, @Email, @Address, @Address2)";
            var parameters = new DynamicParameters();
            parameters.Add("VendorId", model.VendorId, DbType.Guid);
            parameters.Add("Name", model.Name, DbType.String);
            parameters.Add("Description", model.Description, DbType.String);
            parameters.Add("Phone", model.Phone, DbType.String);
            parameters.Add("Email", model.Email, DbType.String);
            parameters.Add("Address", model.Address, DbType.String);
            parameters.Add("Address2", model.Address2, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                var id = await connection.QuerySingleAsync<Guid>(query, parameters);
                var createdVendor = new Vendor
                {
                    VendorId = id,
                    Name = model.Name,
                    Description = model.Description,
                    Phone = model.Phone,
                    Email = model.Email,
                    Address = model.Address,
                    Address2 = model.Address2
                };
                return createdVendor;
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            var query = "DELETE FROM Vendor where VendorId = @Id";
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { id });
            }
        }

        public async Task<IEnumerable<Vendor>> GetAllAsync()
        {
            var query = "SELECT * FROM [dbo].[Vendor]";
            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var vendors = await connection.QueryAsync<Vendor>(query);
                    return vendors.ToList();
                }
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public async Task<Vendor> GetByIdAsync(Guid VendorId)
        {
            var query = "SELECT * FROM VEndor WHERE VendorId = @VendorId";
            using (var connection = _context.CreateConnection())
            {
                var user = await connection.QuerySingleOrDefaultAsync<Vendor>(query, new { VendorId });
                return user;
            }
        }

        public async Task UpdateAsync(Guid id, Vendor model)
        {
            var query = "UPDATE [dbo].[Vendor] SET [Name] = @Name, [Description] = @Description, [Phone] = @Phone," +
                " [Email] = @Email, [Address] = @Address, [Address2] = @Address2 WHERE VendorId = @id";
            var parameters = new DynamicParameters();
            parameters.Add("VendorId", id, DbType.Guid);
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
