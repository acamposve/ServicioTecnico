using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicioTecnico.Application.Interfaces;
using ServicioTecnico.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorController : ControllerBase
    {
        private readonly IVendorService _vendorService;
        public VendorController(IVendorService vendorService)
        {
            _vendorService = vendorService;
        }


        [HttpPost]
        public IActionResult Create(Vendor model)
        {
            return Ok(_vendorService.Create(model));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var customers = await _vendorService.GetAll();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var customer = await _vendorService.GetById(id);
            return Ok(customer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, Vendor model)
        {
            await _vendorService.Update(id, model);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var dbCustomer = await _vendorService.GetById(id);
                if (dbCustomer == null)
                    return NotFound();
                await _vendorService.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }
    }
}
