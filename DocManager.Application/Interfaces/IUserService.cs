using ServicioTecnico.Domain.Entities;
using ServicioTecnico.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServicioTecnico.Application.Interfaces
{
    public interface IUserService
    {
        Task<User> Authenticate(string username, string password);
        Task<IEnumerable<User>> GetAll();
        Task<User> GetById(int id);
        Task<User> Create(CreateRequest model);
        Task Update(int id, UpdateRequest model);
        Task Delete(int id);
    }
}
