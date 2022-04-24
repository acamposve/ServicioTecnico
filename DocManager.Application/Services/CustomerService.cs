using AutoMapper;
using Microsoft.Extensions.Options;
using ServicioTecnico.Application.Interfaces;
using ServicioTecnico.Domain.Entities;
using ServicioTecnico.Domain.Models.Customer;
using ServicioTecnico.Infrastructure.Interfaces;
using ServicioTecnico.Infrastructure.Shared.Helpers;
using ServicioTecnico.Infrastructure.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioTecnico.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepositoryAsync _customerRepository;
        private readonly ILoggerManager _logger;
        private readonly AppSettings _appSettings;
        private readonly IMapper _mapper;

        public CustomerService(IOptions<AppSettings> appSettings,
                                ICustomerRepositoryAsync customerRepository,
                                ILoggerManager logger, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _logger = logger;
            _appSettings = appSettings.Value;
            _mapper = mapper;

        }

        public async Task<Customer> Create(Customer model)
        {
            var cus = new Customer();
            try
            {
                cus.Email = model.Email;
                cus.Address = model.Address;
                cus.Address2 = model.Address2;
                cus.Description = model.Description;
                cus.Name = model.Name;
                cus.Phone = model.Phone;
                cus.CustomerId = Guid.NewGuid();

            }
            catch (Exception ex)
            {

                throw ex;
            }

            return await _customerRepository.CreateAsync(cus);
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {

            var customers = await _customerRepository.GetAllAsync();

            return customers;
        }

        public async Task<Customer> GetById(Guid id)
        {
            return await _customerRepository.GetByIdAsync(id);
        }

        public async Task Update(Guid id, Customer model)
        {

            await _customerRepository.UpdateAsync(id, model);
        }
        public async Task Delete(Guid id)
        {

            await _customerRepository.DeleteAsync(id);
        }
    }
}
