using ServicioTecnico.Domain.Models.ReceiptsFiles;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServicioTecnico.Application.Interfaces
{
    public interface IReceiptsFilesService
    {
        Task<int> Create(CreateRequest model);


        void Delete(int id);
    }
}
