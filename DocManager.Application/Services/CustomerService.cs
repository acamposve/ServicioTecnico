﻿using AutoMapper;
using Microsoft.Extensions.Options;
using ServicioTecnico.Application.Interfaces;
using ServicioTecnico.Domain.Entities;
using ServicioTecnico.Domain.Models.Customer;
using ServicioTecnico.Infrastructure.Interfaces;
using ServicioTecnico.Infrastructure.Shared.Helpers;
using ServicioTecnico.Infrastructure.Shared.Interfaces;
using System;
using System.Collections.Generic;
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

        public async Task<Customer> Create(CreateRequest model)
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

        public async Task<IReadOnlyList<Customer>> GetAllAsync()
        {
            return await _customerRepository.GetAllAsync();
        }

        public async Task<Customer> GetByIdAsync(Guid id)
        {
            return await _customerRepository.GetByIdAsync(id);
        }
    }
}