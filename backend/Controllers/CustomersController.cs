using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ServicioTecnico.Application.Interfaces;
using ServicioTecnico.Domain.Models.Customer;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        public IActionResult Create(CreateRequest model)
        {
            _customerService.Create(model);
            return Ok(new { message = "Customer created" });
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var customers =  _customerService.GetAllAsync();
            return Ok(customers);
        }
    }
}
