using AutoMapper;
using HotelManagement.Core.Entities;
using HotelManagement.Core.Models.Request;
using HotelManagement.Core.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.Core.MappingProfile
{
    public class RoomTypeMappingProfile : Profile
    {
        public RoomTypeMappingProfile()
        {
            CreateMap<RoomType, RoomTypeResponseModel>();
            CreateMap<RoomTypeCreateRequest,RoomType>();
            CreateMap<Room, RoomResponseModel>();
            CreateMap<RoomCreateRequest, Room>();
            CreateMap<RoomResponseModel, RoomCreateRequest>();
            CreateMap<Customer, CustomerResponseModel>();
            CreateMap<CustomerCreateRequest, Customer>();
            CreateMap<Service, ServiceResponseModel>();
            CreateMap<ServiceCreateRequest, Service>();
        }
    }
}
