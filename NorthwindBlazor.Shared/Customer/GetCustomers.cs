using System.Collections.Generic;
using MediatR;

namespace NorthwindBlazor.Shared.Customer
{
    public class GetCustomers : IRequest<IEnumerable<CustomerModel>>
    {
        public int PageIndex { get; set; }
        
        public int PageSize { get; set; }
    }
}