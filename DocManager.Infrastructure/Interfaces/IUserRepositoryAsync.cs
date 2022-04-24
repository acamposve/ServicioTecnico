using ServicioTecnico.Domain.Entities;
using ServicioTecnico.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServicioTecnico.Infrastructure.Interfaces
{
    public interface IUserRepositoryAsync
    {
        Task<User> Authenticate(string username, string password);
        Task DeleteUserAsync(int id);
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetByIdAsync(int id);
        Task UpdateAsync(int id, UpdateRequest model);
        Task<User> CreateAsync(CreateRequest model);
    }
}
