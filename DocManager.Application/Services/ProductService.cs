using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Options;
using ServicioTecnico.Application.Interfaces;
using ServicioTecnico.Domain.Entities;
using ServicioTecnico.Infrastructure.Interfaces;
using ServicioTecnico.Infrastructure.Shared.Helpers;
using ServicioTecnico.Infrastructure.Shared.Interfaces;

namespace ServicioTecnico.Application.Services
{
    public class ProductService: IProductService
    {
        private readonly IProductRepositoryAsync _productRepository;
        private readonly ILoggerManager _logger;
        private readonly AppSettings _appSettings;
        private readonly IMapper _mapper;
        public ProductService(IOptions<AppSettings> appSettings,
                                IProductRepositoryAsync productRepository,
                                ILoggerManager logger, IMapper mapper)
        {
            _productRepository = productRepository;
            _logger = logger;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }

        public async Task<Product> Create(Product model)
        {
            return await _productRepository.CreateAsync(model);
        }

        public async Task<IEnumerable<Product>> GetAll()
        {

            var customers = await _productRepository.GetAllAsync();

            return customers;
        }

        public async Task<Product> GetById(Guid id)
        {
            return await _productRepository.GetByIdAsync(id);
        }

        public async Task Update(Guid id, Product model)
        {

            await _productRepository.UpdateAsync(id, model);
        }
        public async Task Delete(Guid id)
        {

            await _productRepository.DeleteAsync(id);
        }
    }
}
