using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Northwind.Ef;
using NorthwindBlazor.Shared;
using NorthwindBlazor.Shared.Customer;

namespace NorthwindApplication.Customer
{

    public class GetCustomerHandler : IRequestHandler<GetCustomer, CustomerModel>
    {

        private readonly NorthwindContext _dbCtx;

        public GetCustomerHandler(NorthwindContext dbCtx)
        {
            _dbCtx = dbCtx;
        }

        public async Task<CustomerModel> Handle(GetCustomer request, CancellationToken cancellationToken)
        {
            return await _dbCtx.Customers.Select(c => new CustomerModel()
            {
                Address = c.Address,
                City = c.City,
                CompanyName = c.CompanyName,
                ContactName = c.ContactName,
                CustomerId = c.CustomerId
            })
            .Where(c => c.CustomerId == request.CustomerId)
            .FirstOrDefaultAsync(cancellationToken);
        }
    }
    
}