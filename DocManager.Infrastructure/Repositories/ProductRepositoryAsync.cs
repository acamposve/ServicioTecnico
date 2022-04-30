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
    public class ProductRepositoryAsync : IProductRepositoryAsync
    {
        private readonly DapperContext _context;
        private readonly ILoggerManager _logger;
        public ProductRepositoryAsync(DapperContext context, ILoggerManager logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Product> CreateAsync(Product model)
        {
            var query = "INSERT INTO [dbo].[Product] ([ProductId],[Name],[Description],[PriceSell],[PricePurchase]" +
                ") VALUES (@ProductId, @Name, @Description, @PriceSell, @PricePurchase)";
            var parameters = new DynamicParameters();
            parameters.Add("ProductId", model.ProductId, DbType.Guid);
            parameters.Add("Name", model.Name, DbType.String);
            parameters.Add("Description", model.Description, DbType.String);
            parameters.Add("PriceSell", model.PriceSell, DbType.Decimal);
            parameters.Add("PricePurchase", model.PricePurchase, DbType.Decimal);

            using (var connection = _context.CreateConnection())
            {
                var id = await connection.QuerySingleAsync<Guid>(query, parameters);
                var createdProduct = new Product
                {
                    ProductId = id,
                    Name = model.Name,
                    Description = model.Description,
                    PriceSell = model.PriceSell,
                    PricePurchase = model.PricePurchase
                };
                return createdProduct;
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            var query = "DELETE FROM Product where ProductId = @Id";
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { id });
            }
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            var query = "SELECT * FROM [dbo].[Product]";
            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var products = await connection.QueryAsync<Product>(query);
                    return products.ToList();
                }
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public async Task<Product> GetByIdAsync(Guid ProductId)
        {
            var query = "SELECT * FROM PRoduct WHERE ProductId = @ProductId";
            using (var connection = _context.CreateConnection())
            {
                var user = await connection.QuerySingleOrDefaultAsync<Product>(query, new { ProductId });
                return user;
            }
        }

        public async Task UpdateAsync(Guid id, Product model)
        {
            var query = "UPDATE [dbo].[Product] SET [Name] = @Name, [Description] = @Description, [PriceSell] = @PriceSell," +
                " [PricePurchase] = @PricePurchase WHERE ProductId = @id";
            var parameters = new DynamicParameters();
            parameters.Add("ProductId", id, DbType.Guid);
            parameters.Add("Name", model.Name, DbType.String);
            parameters.Add("Description", model.Description, DbType.String);
            parameters.Add("PriceSell", model.PriceSell, DbType.String);
            parameters.Add("PricePurchase", model.PricePurchase, DbType.String);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
