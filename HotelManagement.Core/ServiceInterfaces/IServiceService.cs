using HotelManagement.Core.Models.Request;
using HotelManagement.Core.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Core.ServiceInterfaces
{
    public interface IServiceService
    {
        Task<IEnumerable<ServiceResponseModel>> GetServices();
        Task<ServiceResponseModel> GetService(int id);
        Task<ServiceResponseModel> AddService(ServiceCreateRequest r);
        Task<ServiceResponseModel> PatchService(ServiceCreateRequest r);
        Task<ServiceResponseModel> DeleteService(int id);
    }
}
