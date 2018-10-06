using System.Reflection.Metadata.Ecma335;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Northwind.Ef;
using NorthwindBlazor.Shared.Customer;

namespace NorthwindApplication.Customer
{
    public class SaveCustomerHandler: IRequestHandler<SaveCustomer,CustomerModel>
    {
        private readonly NorthwindContext _dbCtx;
        private readonly IMediator _mediator;

        public SaveCustomerHandler(NorthwindContext dbCtx, IMediator mediator)
        {
            _dbCtx = dbCtx;
            _mediator = mediator;
        }

        public async Task<CustomerModel> Handle(SaveCustomer request, CancellationToken cancellationToken)
        {
            var isNew = string.IsNullOrEmpty(request.Customer.CustomerId);

            var customerEntity = isNew
                ? new Northwind.Domain.Customers.Customer()
                : await _dbCtx.Customers.FindAsync(request.Customer.CustomerId);

            customerEntity.Address = request.Customer.Address;
            customerEntity.City = request.Customer.City;
            customerEntity.CompanyName = request.Customer.CompanyName;
            customerEntity.ContactName = request.Customer.ContactName;

            if (isNew) _dbCtx.Customers.Add(customerEntity);
            await _dbCtx.SaveChangesAsync(cancellationToken);

            return await _mediator.Send(new GetCustomer(customerEntity.CustomerId), cancellationToken);
        }
    }
}