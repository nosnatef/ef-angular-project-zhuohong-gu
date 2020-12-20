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
    public class RoomTypeService : IRoomTypeService
    {

        private readonly IRoomTypeRepository _repository;
        private readonly IMapper _mapper;

        public RoomTypeService(IRoomTypeRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<RoomTypeResponseModel> AddRoomType(RoomTypeCreateRequest roomTypeCreateRequest)
        {
            var roomType = _mapper.Map<RoomType>(roomTypeCreateRequest);
            var createdRoomType = await _repository.AddAsync(roomType);
            return _mapper.Map<RoomTypeResponseModel>(createdRoomType);
        }


        public async Task<RoomTypeResponseModel> GetRoomType(int id)
        {
            var roomType = await _repository.GetByIdAsync(id);
            var response = _mapper.Map<RoomTypeResponseModel>(roomType);
            return response;
        }

        public async Task<IEnumerable<RoomTypeResponseModel>> GetRoomTypes()
        {
            var types = await _repository.GetRoomTypes();
            var response = _mapper.Map<IEnumerable<RoomTypeResponseModel>>(types);
            return response;
        }

        public async Task<RoomTypeResponseModel> PatchRoomType(RoomTypeCreateRequest r)
        {
            var type = _mapper.Map<RoomType>(r);
            var updatedType = await _repository.UpdateAsync(type);
            return _mapper.Map<RoomTypeResponseModel>(updatedType);
        }

        public async Task<RoomTypeResponseModel> DeleteRoomType(int id)
        {
            var roomType = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(roomType);
            return _mapper.Map<RoomTypeResponseModel>(roomType);
        }

    }
}
