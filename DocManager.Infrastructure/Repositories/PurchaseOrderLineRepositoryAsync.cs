using Dapper;
using ServicioTecnico.Domain.Entities;
using ServicioTecnico.Infrastructure.Context;
using ServicioTecnico.Infrastructure.Interfaces;
using ServicioTecnico.Infrastructure.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioTecnico.Infrastructure.Repositories
{
    public class PurchaseOrderLineRepositoryAsync : IPurchaseOrderLineRepositoryAsync
    {
        private readonly DapperContext _context;
        private readonly ILoggerManager _logger;
        public PurchaseOrderLineRepositoryAsync(DapperContext context, ILoggerManager logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<IEnumerable<PurchaseOrderLine>> GetAllAsync()
        {
            var query = "SELECT * FROM [dbo].[PurchaseOrderLine]";
            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var users = await connection.QueryAsync<PurchaseOrderLine>(query);
                    return users.ToList();
                }
            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}
