using AutoMapper;
using HotelManagement.Core.Entities;
using HotelManagement.Core.Models.Request;
using HotelManagement.Core.Models.Response;
using HotelManagement.Core.RepositoryInterfaces;
using HotelManagement.Core.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Infrastructure.Services
{
    public class ServiceService : IServiceService
    {

        private readonly IServiceRepository _repository;
        private readonly IMapper _mapper;

        public ServiceService(IServiceRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        public async Task<ServiceResponseModel> DeleteService(int id)
        {
            var service = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(service);
            return _mapper.Map<ServiceResponseModel>(service);
        }

        public async Task<IEnumerable<ServiceResponseModel>> GetServices()
        {
            var services = await _repository.GetServices();
            var response = _mapper.Map<IEnumerable<ServiceResponseModel>>(services);
            return response;
        }

        public async Task<ServiceResponseModel> GetService(int id)
        {
            var service = await _repository.GetByIdAsync(id);
            var response = _mapper.Map<ServiceResponseModel>(service);
            return response;
        }

        public async Task<ServiceResponseModel> PatchService(ServiceCreateRequest r)
        {
            var service = _mapper.Map<Service>(r);
            service.ServiceDate = DateTime.Now;
            var updatedService = await _repository.UpdateAsync(service);
            return _mapper.Map<ServiceResponseModel>(updatedService);
        }


        public async Task<ServiceResponseModel> AddService(ServiceCreateRequest r)
        {
            var service = _mapper.Map<Service>(r);
            var createdService = await _repository.AddAsync(service);
            return _mapper.Map<ServiceResponseModel>(createdService);
        }
    }
}
