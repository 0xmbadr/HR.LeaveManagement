using AutoMapper;
using HR.LeaveManagement.Application.Dtos.LeaveAllocation;
using HR.LeaveManagement.Application.Dtos.LeaveRequest;
using HR.LeaveManagement.Application.Dtos.LeaveType;
using HR.LeaveManagement.Application.LeaveAllocation.Dtos;
using HR.LeaveManagement.Application.LeaveType.Dtos;
using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region LeaveType Mappings
            CreateMap<Domain.LeaveType, LeaveTypeDto>().ReverseMap();
            CreateMap<Domain.LeaveType, CreateLeaveTypeDto>().ReverseMap();
            #endregion

            #region LeaveRequest Mappings
            CreateMap<LeaveRequest, LeaveRequestDto>().ReverseMap();
            CreateMap<LeaveRequest, LeaveRequestListDto>().ReverseMap();
            CreateMap<LeaveRequest, CreateLeaveRequestDto>().ReverseMap();
            CreateMap<LeaveRequest, UpdateLeaveRequestDto>().ReverseMap();
            #endregion

            #region LeaveAllocation Mappings
            CreateMap<Domain.LeaveAllocation, LeaveAllocationDto>().ReverseMap();
            CreateMap<Domain.LeaveAllocation, CreateLeaveAllocationDto>().ReverseMap();
            CreateMap<Domain.LeaveAllocation, UpdateLeaveAllocationDto>().ReverseMap();
            #endregion
        }
    }
}
