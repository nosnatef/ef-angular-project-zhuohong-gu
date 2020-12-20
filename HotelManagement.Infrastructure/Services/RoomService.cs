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
    public class RoomService : IRoomService
    {


        private readonly IRoomRepository _repository;
        private readonly IRoomTypeService _RTService;
        private readonly IServiceRepository _SRepository;
        private readonly IMapper _mapper;

        public RoomService(IRoomRepository repository, IMapper mapper, IRoomTypeService RTService,IServiceRepository SRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _RTService = RTService;
            _SRepository = SRepository;
        }

        public async Task<IEnumerable<RoomResponseModel>> GetRooms()
        {
            var rooms = await _repository.GetRooms();
            var response = _mapper.Map<IEnumerable<RoomResponseModel>>(rooms);
            foreach(var re in response)
            {
                re.RoomType = await _RTService.GetRoomType(re.RoomTypeId);
                var services = await _SRepository.ListAsync(s => s.RoomId == re.Id);
                re.Services = _mapper.Map<IEnumerable<ServiceResponseModel>>(services);
            }
            return response;
        }

        public async Task<RoomResponseModel> GetRoom(int id)
        {
            var room = await _repository.GetByIdAsync(id);
            if (room == null) return null;
            var response = _mapper.Map<RoomResponseModel>(room);
            response.RoomType = await _RTService.GetRoomType(response.RoomTypeId);
            var services = await _SRepository.ListAsync(s => s.RoomId == id);
            response.Services = _mapper.Map<IEnumerable<ServiceResponseModel>>(services);
            return response;
        }

        public async Task<RoomResponseModel> AddRoom(RoomCreateRequest roomCreateRequest)
        {
            var room = _mapper.Map<Room>(roomCreateRequest);
            var createdRoom = await _repository.AddAsync(room);
            return _mapper.Map<RoomResponseModel>(createdRoom);
        }

        public async Task<RoomResponseModel> PatchRoom(RoomCreateRequest r)
        {
            var room = _mapper.Map<Room>(r);
            var updatedRoom = await _repository.UpdateAsync(room);
            return _mapper.Map<RoomResponseModel>(updatedRoom);
        }

        public async Task<RoomResponseModel> DeleteRoom(int id)
        {
            var room = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(room);
            return _mapper.Map<RoomResponseModel>(room);
        }

        public async Task<RoomResponseModel> bookRoom(int id)
        {
            var room = await _repository.GetByIdAsync(id);
            room.Status = false;
            return _mapper.Map<RoomResponseModel>(room);
        }
    }
}
