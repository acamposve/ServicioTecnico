using ServicioTecnico.Domain.DTOs.Email;
using System.Threading.Tasks;

namespace ServicioTecnico.Infrastructure.Shared.Interfaces
{
    public interface IEmailService
    {
        Task SendAsync(EmailRequest request);
    }
}
