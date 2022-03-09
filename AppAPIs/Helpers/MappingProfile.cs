using AppAPIs.Dtos;
using AutoMapper;

namespace AppAPIs.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Journey, JourneyDto>();
            CreateMap<JourneyDto, Journey>();
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
            CreateMap<Driver, DriverDto>();
            CreateMap<DriverDto, Driver>();
            CreateMap<CarType, CarTypeDto>();
            CreateMap<CarTypeDto, CarType>();

        }
    }
}
