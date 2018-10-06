using System.Collections.Generic;

namespace NorthwindBlazor.Shared.Customer
{
    public class GetCustomersResponse
    {
        public IEnumerable<CustomerModel> Customers { get; set; }

        public int PageIndex { get; set; }

        public int TotalRecords { get; set; }
    }
}