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
    public class GoodsReceiveRepository : IGoodsReceiveRepository
    {
        private readonly DapperContext _context;
        private readonly ILoggerManager _logger;
        public GoodsReceiveRepository(DapperContext context, ILoggerManager logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<GoodsReceive> CreateAsync(GoodsReceive model)
        {
            model.GoodsReceiveId = Guid.NewGuid();

            var query = "INSERT INTO [dbo].[GoodsReceive] ([GoodsReceiveId],[Number],[Description],[GoodsReceiveDate],[PurchaseOrderId]) VALUES (@GoodsReceiveId, @Number, @Description, @GoodsReceiveDate, @PurchaseOrderId)";
            var parameters = new DynamicParameters();
            parameters.Add("GoodsReceiveId", model.GoodsReceiveId, DbType.Guid);
            parameters.Add("Number", model.Number, DbType.String);
            parameters.Add("Description", model.Description, DbType.String);
            parameters.Add("GoodsReceiveDate", model.GoodsReceiveDate, DbType.DateTimeOffset);
            parameters.Add("PurchaseOrderId", model.PurchaseOrderId, DbType.Guid);

            using var connection = _context.CreateConnection();
            var id = await connection.QuerySingleAsync<Guid>(query, parameters);
            var createdUser = new GoodsReceive
            {
                GoodsReceiveId = id,
                Number = model.Number,
                Description = model.Description,
                GoodsReceiveDate = model.GoodsReceiveDate,
                PurchaseOrderId = model.PurchaseOrderId
            };
            return createdUser;
        }


        public async Task<IEnumerable<GoodsReceive>> GetAllAsync()
        {
            var query = "SELECT dbo.GoodsReceive.GoodsReceiveId, dbo.GoodsReceive.Number, dbo.GoodsReceive.Description, dbo.GoodsReceive.GoodsReceiveDate, dbo.PurchaseOrder.PurchaseOrderId, dbo.PurchaseOrder.Number AS PurchaseOrderNumber, dbo.PurchaseOrder.Description AS PurchaseOrderDescription, dbo.PurchaseOrder.PurchaseOrderDate, dbo.Vendor.VendorId, dbo.Vendor.Name, dbo.Vendor.Description AS VendorDescription FROM dbo.GoodsReceive INNER JOIN dbo.PurchaseOrder ON dbo.GoodsReceive.PurchaseOrderId = dbo.PurchaseOrder.PurchaseOrderId INNER JOIN dbo.Vendor ON dbo.PurchaseOrder.VendorId = dbo.Vendor.VendorId";
            try
            {
                using var connection = _context.CreateConnection();
                var users = await connection.QueryAsync<GoodsReceive>(query);
                return users.ToList();
            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}
