using AGData.BookMySeat.Domain.Entities;
using AGData.BookMySeat.WebAPI.DTOs;
using AutoMapper;

namespace AGData.BookMySeat.WebAPI.AutoMapper
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AddEmployeeRequestDto,Employee>().ReverseMap();
            CreateMap<AddBookingRequestDto,BookingRecord>().ReverseMap();
            CreateMap<AddVisitorRequestDto,Visitor>().ReverseMap();
            CreateMap<AddResourceRequestDto,Resource>().ReverseMap();
        }
    }
}
