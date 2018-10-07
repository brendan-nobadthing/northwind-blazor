using System.Collections.Generic;
using MediatR;

namespace NorthwindBlazor.Shared.Customer
{
    public class GetCustomers : IRequest<IEnumerable<CustomerModel>>
    {
        public string SearchText { get; set; }
    }
}