using AutoMapper;
using HR.LeaveManagement.Application.Dtos.LeaveRequest;
using HR.LeaveManagement.Application.LeaveAllocation.Dtos;
using HR.LeaveManagement.Application.LeaveType.Dtos;
using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LeaveRequest, LeaveRequestDto>().ReverseMap();
            CreateMap<LeaveRequest, LeaveRequestListDto>().ReverseMap();
            CreateMap<Domain.LeaveType, LeaveTypeDto>().ReverseMap();
            CreateMap<Domain.LeaveAllocation, LeaveAllocationDto>().ReverseMap();
        }
    }
}
