using MediatR;

namespace NorthwindBlazor.Shared.Customer
{
    public class GetCustomer: IRequest<CustomerModel>
    {
        public GetCustomer(string customerId)
        {
            CustomerId = customerId;
        }
        public string CustomerId { get; private set; }
    }
}