using Customer.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Customer.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]/[action]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _repository;

        public CustomerController(ICustomerRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpPost]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Entities.Customer>> Create([FromBody] Entities.Customer customer)
        {
            await _repository.CreateAsync(customer);

            return Ok(customer.Id);
        }

        [HttpPut]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update([FromBody] Entities.Customer customer)
        {
            return Ok(await _repository.UpdateAsync(customer));
        }

        [HttpDelete("{id:length(24)}")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Delete(string id)
        {
            return Ok(await _repository.DeleteAsync(id));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Entities.Customer>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Entities.Customer>>> Get()
        {
            var products = await _repository.GetAsync();
            return Ok(products);
        }

        [HttpGet("{id:length(24)}")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Entities.Customer), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Entities.Customer>> Get(string id)
        {
            var product = await _repository.GetAsync(id);

            if (product == null)
                return NotFound(id);

            return Ok(product);
        }

        [HttpGet("{id:length(24)}")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Validate(string id)
        {
            var exist = await _repository.ValidateAsync(id);
            if (exist)
                return Ok(exist);
            else
                return NotFound(exist);

        }
    }
}
