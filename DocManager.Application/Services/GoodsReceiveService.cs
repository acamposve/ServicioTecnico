using AutoMapper;
using Microsoft.Extensions.Options;
using ServicioTecnico.Application.Interfaces;
using ServicioTecnico.Domain.Entities;
using ServicioTecnico.Domain.Models.GoodsReceive;
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
    public class GoodsReceiveService: IGoodsReceiveService
    {
        private readonly IGoodsReceiveRepository _goodsReceiveRepository;
        private readonly ILoggerManager _logger;
        private readonly AppSettings _appSettings;
        private readonly IMapper _mapper;
        public GoodsReceiveService(IOptions<AppSettings> appSettings,
                                IGoodsReceiveRepository goodsReceiveRepository,
                                ILoggerManager logger, IMapper mapper)
        {
            _goodsReceiveRepository = goodsReceiveRepository;
            _logger = logger;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<GoodsReceive> Create(CreateRequest model)
        {
            var gr = new GoodsReceive
            {
                Description = model.Description,
                GoodsReceiveDate = model.GoodsReceiveDate,
                PurchaseOrderId = model.PurchaseOrderId
            };

            return await _goodsReceiveRepository.CreateAsync(gr);
        }
    }
}
