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

        // GET: api/Customers
        [HttpGet]
        public IEnumerable<CustomerViewModel> ListarTodos()
        {
            return _customerAppService.ObterTodos();
        }

        // GET: api/Customers/5
        public CustomerViewModel Get(Guid id)
        {
            return _customerAppService.ObterPorId(id);
        }

        // POST: api/Customers
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Customers/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Customers/5
        public void Delete(int id)
        {
        }
    }
}
