using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicioTecnico.Application.Interfaces;
using ServicioTecnico.Domain.Entities;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }



        [HttpPost]
        public IActionResult Create(Product model)
        {
            return Ok(_productService.Create(model));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var customers = await _productService.GetAll();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var customer = await _productService.GetById(id);
            return Ok(customer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, Product model)
        {
            await _productService.Update(id, model);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var dbCustomer = await _productService.GetById(id);
                if (dbCustomer == null)
                    return NotFound();
                await _productService.Delete(id);
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
