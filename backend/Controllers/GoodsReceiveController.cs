using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicioTecnico.Application.Interfaces;
using ServicioTecnico.Domain.Entities;
using ServicioTecnico.Domain.Models.GoodsReceive;
using ServicioTecnico.Infrastructure.Shared.Helpers;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoodsReceiveController : ControllerBase
    {
        private readonly IGoodsReceiveService _service;

        public GoodsReceiveController(IGoodsReceiveService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Create(CreateRequest model)
        {
            return Ok(_service.Create(model));
        }
    }
}
