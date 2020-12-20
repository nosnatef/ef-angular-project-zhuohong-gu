using AutoMapper;
using HotelManagement.Core.Entities;
using HotelManagement.Core.Models.Request;
using HotelManagement.Core.Models.Response;
using HotelManagement.Core.RepositoryInterfaces;
using HotelManagement.Core.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Infrastructure.Services
{
    public class CustomerService : ICustomerService
    {

        private readonly ICustomerRepository _repository;
        private readonly IMapper _mapper;
        private readonly IRoomService _roomService;

        public CustomerService(ICustomerRepository repository, IMapper mapper, IRoomService roomService)
        {
            _repository = repository;
            _mapper = mapper;
            _roomService = roomService;
        }

        public async Task<CustomerResponseModel> AddCustomer(CustomerCreateRequest customerCreateRequest)
        {
            var customer = _mapper.Map<Customer>(customerCreateRequest);
            var bookingRoom = await _roomService.GetRoom(customer.RoomId);
            if (bookingRoom == null || !bookingRoom.Status)
            {
                return null;
            }
            await _roomService.bookRoom(bookingRoom.Id);
            var createdCustomer = await _repository.AddAsync(customer);
            return _mapper.Map<CustomerResponseModel>(createdCustomer);
        }

        public async Task<CustomerResponseModel> DeleteCustomer(int id)
        {
            var customer = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(customer);
            return _mapper.Map<CustomerResponseModel>(customer);
        }

        public async Task<CustomerResponseModel> GetCustomer(int id)
        {
            var customer = await _repository.GetByIdAsync(id);
            var customerRoom = await _roomService.GetRoom(customer.RoomId);
            var response = _mapper.Map<CustomerResponseModel>(customer);
            response.Room = customerRoom;
            return response;
        }

        public async Task<IEnumerable<CustomerResponseModel>> GetCustomers()
        {
            var customers = await _repository.GetCustomers();
            var response = _mapper.Map<IEnumerable<CustomerResponseModel>>(customers);
            return response;
        }


        public async Task<CustomerResponseModel> PatchCustomer(CustomerCreateRequest r)
        {
            var customer = _mapper.Map<Customer>(r);
            customer.Checkin = DateTime.Now;
            var updatedCustomer = await _repository.UpdateAsync(customer);
            var bookingRoom = await _roomService.GetRoom(customer.RoomId);
            if (bookingRoom == null || !bookingRoom.Status)
            {
                return null;
            }
            await _roomService.bookRoom(bookingRoom.Id);
            return _mapper.Map<CustomerResponseModel>(updatedCustomer);
        }
    }
}
