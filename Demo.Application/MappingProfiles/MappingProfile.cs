using AutoMapper;
using Demo.Domain.DTOs;
using Demo.Infrastructure.Entity;

namespace Demo.Application.MappingProfiles
{
    internal class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<EmployeeMaster, EmployeeDTO>()
                .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.EmpId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.EmpName))
                .ForMember(dest => dest.MobileNo, opt => opt.MapFrom(src => src.Mobile))
                .ForMember(dest => dest.EmailID, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.CreateDate, opt => opt.MapFrom(src => src.CreateDate))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive));
        }
    }
}
