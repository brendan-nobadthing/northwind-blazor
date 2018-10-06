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

        [HttpGet("[action]")]
        public  Task<IEnumerable<CustomerModel>> List(CancellationToken cancellationToken)
        {
            return _mediator.Send(new GetCustomers(), cancellationToken);
        }
    }
}
