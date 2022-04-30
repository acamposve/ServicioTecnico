using AutoMapper;
using Microsoft.Extensions.Options;
using ServicioTecnico.Application.Interfaces;
using ServicioTecnico.Domain.Entities;
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
    public class VendorService : IVendorService
    {
        private readonly IVendorRepositoryAsync _vendorRepository;
        private readonly ILoggerManager _logger;
        private readonly AppSettings _appSettings;
        private readonly IMapper _mapper;
        public VendorService(IOptions<AppSettings> appSettings,
                                IVendorRepositoryAsync vendorRepository,
                                ILoggerManager logger, IMapper mapper)
        {
            _vendorRepository = vendorRepository;
            _logger = logger;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }

        public async Task<Vendor> Create(Vendor model)
        {
            return await _vendorRepository.CreateAsync(model);
        }

        public async Task<IEnumerable<Vendor>> GetAll()
        {

            var customers = await _vendorRepository.GetAllAsync();

            return customers;
        }

        public async Task<Vendor> GetById(Guid id)
        {
            return await _vendorRepository.GetByIdAsync(id);
        }

        public async Task Update(Guid id, Vendor model)
        {

            await _vendorRepository.UpdateAsync(id, model);
        }
        public async Task Delete(Guid id)
        {

            await _vendorRepository.DeleteAsync(id);
        }
    }
}
