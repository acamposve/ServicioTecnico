using ServicioTecnico.Domain.Models.ReceiptsFiles;
using System.Threading.Tasks;

namespace ServicioTecnico.Infrastructure.Interfaces
{
    public interface IReceiptsFilesRepository
    {
        Task<int> Create(CreateRequest model);
        void Delete(int id);
    }
}
