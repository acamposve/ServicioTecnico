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
        Task<int> CreateAsync(CreateRequest model);
        void UpdateAsync(int id, UpdateRequest model);
        Task<User> GetByIdAsync(int id);
        Task<IReadOnlyList<User>> GetAllAsync();
        void DeleteAsync(int id);
    }
}
