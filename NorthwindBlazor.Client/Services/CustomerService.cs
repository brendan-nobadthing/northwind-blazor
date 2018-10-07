using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Blazor;
using NorthwindBlazor.Shared.Customer;

namespace NorthwindBlazor.Client.Services
{

    public interface ICustomerService
    {
        Task<IEnumerable<CustomerModel>> GetCustomers();

        Task<CustomerModel> GetCustomer(string customerId);

        Task<CustomerModel> SaveCustomer(CustomerModel customer);

    }
    
    public class CustomerService : ICustomerService
    {

        private readonly HttpClient _httpClient;

        public CustomerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<IEnumerable<CustomerModel>> GetCustomers()
        {
            return await _httpClient.GetJsonAsync<CustomerModel[]>("api/customer/list");
        }

        public async Task<CustomerModel> GetCustomer(string customerId)
        {
            return await _httpClient.GetJsonAsync<CustomerModel>($"/api/customer/get/{customerId}");
        }

        public async Task<CustomerModel> SaveCustomer(CustomerModel customer)
        {
            var validator = new CustomerModelValidator();
            validator.ValidateAndThrow(customer);
            
            return await _httpClient.PostJsonAsync<CustomerModel>("/api/customer/save", customer);
        }
    }
}