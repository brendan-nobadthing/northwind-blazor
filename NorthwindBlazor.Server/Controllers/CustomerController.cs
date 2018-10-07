using NorthwindBlazor.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NorthwindApplication.Customer;
using NorthwindBlazor.Shared.Customer;

namespace NorthwindBlazor.Server.Controllers
{
    [Route("api/customer")]
    public class CustomerController : Controller
    {

        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("list")]
        public  Task<IEnumerable<CustomerModel>> List([FromQuery]string searchText, CancellationToken cancellationToken)
        {
            return _mediator.Send(new GetCustomers() {SearchText = searchText} , cancellationToken);
        }
           
        [HttpPost("save")]
        public Task<CustomerModel> SaveCustomer ([FromBody] CustomerModel customer, CancellationToken cancellationToken)
        {
            return _mediator.Send(new SaveCustomer(customer), cancellationToken);
        }
        
        [HttpGet("get/{customerId}")]
        public Task<CustomerModel> GetCustomer ([FromRoute] string customerId, CancellationToken cancellationToken)
        {
            return _mediator.Send(new GetCustomer(customerId), cancellationToken);
        }
    }
}
