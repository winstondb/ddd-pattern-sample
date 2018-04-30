using System;
using System.Collections.Generic;
using System.Web.Http;
using Taking.Application.Interfaces;
using Taking.Application.ViewModels;

namespace Taking.Services.REST.Controllers
{
    public class CustomerController : ApiController
    {
        private readonly ICustomerAppService _customerAppService;

        public CustomerController(ICustomerAppService customerAppService)
        {
            _customerAppService = customerAppService;
        }

        // GET: api/Customer
        [HttpGet]
        public IEnumerable<CustomerViewModel> ListarTodos()
        {
            return _customerAppService.ObterTodos();
        }

        // GET: api/Customer/5
        public CustomerViewModel Get(Guid id)
        {
            return _customerAppService.ObterPorId(id);
        }

        // POST: api/Customer
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Customer/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Customer/5
        public void Delete(int id)
        {
        }
    }
}
