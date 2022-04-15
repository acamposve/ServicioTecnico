using Dapper;
using ServicioTecnico.Domain.Models.ReceiptsFiles;
using ServicioTecnico.Infrastructure.Interfaces;
using ServicioTecnico.Infrastructure.Shared.Interfaces;
using System.Data;
using System.Threading.Tasks;

namespace ServicioTecnico.Infrastructure.Repositories
{
    public class ReceiptsFilesRepository : IReceiptsFilesRepository
    {
        private readonly IDapper _dapper;
        private readonly ILoggerManager _logger;
        public ReceiptsFilesRepository(IDapper dapper, ILoggerManager logger)
        {
            _dapper = dapper;
            _logger = logger;
        }

        public async Task<int> Create(CreateRequest model)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("Name", model.Name, DbType.String);
            dbparams.Add("Size", model.Size, DbType.Int32);
            dbparams.Add("Extension", model.Extension, DbType.String);
            dbparams.Add("Path", model.Path, DbType.String);
            dbparams.Add("EmbarqueId", model.EmbarqueId, DbType.Int32);

            dbparams.Add("imageData", model.imageData, DbType.Binary);


            var result = await Task.FromResult(_dapper.Insert<int>("[dbo].[pa_insert_receiptsfiles]", dbparams, commandType: CommandType.StoredProcedure));
            return result;

        }
        //public async void Update(int id, UpdateRequest model)
        //{
        //    var user = await GetById(id);

        //    var userBD = await Task.FromResult(_dapper.Get<Receipt>($"Select * from [Receipts] where Referencia = '{model.Referencia}'", null, commandType: CommandType.Text));

        //    // validate
        //    if (model.Referencia != user.Referencia && userBD != null)
        //        throw new AppException("User with the email '" + model.Referencia + "' already exists");


        //    // copy model to user and save
        //    _mapper.Map(model, user);

        //    var dbparams = new DynamicParameters();
        //    dbparams.Add("id", user.id);
        //    dbparams.Add("Referencia", model.Referencia, DbType.String);
        //    dbparams.Add("FechaArribo", model.FechaArribo, DbType.DateTime);
        //    dbparams.Add("Origen", model.Origen, DbType.String);
        //    dbparams.Add("Destino", model.Destino, DbType.String);
        //    dbparams.Add("StatusId", model.StatusId, DbType.Int32);
        //    dbparams.Add("CantidadContainers", model.CantidadContainers, DbType.String);
        //    dbparams.Add("Mercancia", model.Mercancia, DbType.String);

        //    var updateArticle = Task.FromResult(_dapper.Update<int>("[dbo].[pa_update_receipts]",
        //                    dbparams,
        //                    commandType: CommandType.StoredProcedure));



        //}
        public void Delete(int id)
        {
            try
            {
                var dbPara = new DynamicParameters();
                dbPara.Add("id", id);
                var updateArticle = Task.FromResult(_dapper.Update<int>("[dbo].[pa_delete_receiptfile]", dbPara, commandType: CommandType.StoredProcedure));
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message + " " + ex.InnerException);
                throw;
            }

        }
    }
}
