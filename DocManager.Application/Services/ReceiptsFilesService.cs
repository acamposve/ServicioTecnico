using ServicioTecnico.Application.Interfaces;
using ServicioTecnico.Domain.Models.ReceiptsFiles;
using ServicioTecnico.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServicioTecnico.Application.Services
{
    public  class ReceiptsFilesService : IReceiptsFilesService
    {

        private readonly IReceiptsFilesRepository _repository;

        public ReceiptsFilesService(IReceiptsFilesRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Create(CreateRequest model)
        {
            return await _repository.Create(model);
        }


        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
