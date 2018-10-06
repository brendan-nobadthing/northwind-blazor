using MediatR;

namespace NorthwindBlazor.Shared.Customer
{
    public class SaveCustomer : IRequest<CustomerModel>
    {
        public SaveCustomer(CustomerModel model)
        {
            Customer = model;
        }
           
        public CustomerModel Customer { get; private set; }
        
    }
}