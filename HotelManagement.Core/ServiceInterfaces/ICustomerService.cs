using HotelManagement.Core.Models.Request;
using HotelManagement.Core.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Core.ServiceInterfaces
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerResponseModel>> GetCustomers();
        Task<CustomerResponseModel> GetCustomer(int id);
        Task<CustomerResponseModel> AddCustomer(CustomerCreateRequest r);
        Task<CustomerResponseModel> PatchCustomer(CustomerCreateRequest r);
        Task<CustomerResponseModel> DeleteCustomer(int id);
    }
}
