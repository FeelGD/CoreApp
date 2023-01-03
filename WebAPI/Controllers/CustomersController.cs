using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private ICustomerService _CustomerService;

        public CustomersController(ICustomerService CustomerService)
        {
            _CustomerService = CustomerService;
        }

        [HttpGet("getlist")]
        public IActionResult GetList()
        {
            var result = _CustomerService.GetList();
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult Add(Customer customer)
        {
            var result = _CustomerService.Add(customer);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }
        [HttpPost("update")]
        public IActionResult Update(Customer customer)
        {
            var result = _CustomerService.Update(customer);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }
        [HttpGet("ss")]
        public IActionResult Ss()
        {
            try
            {
                var result = _CustomerService.GetList();
                if (result.Success)
                {
                    return Ok(result.Data);
                }
                return BadRequest(result.Message);

            }
            catch (Exception ex)
            {

                return BadRequest("+++"+ex.ToString());
            }
           
        }
    }
}