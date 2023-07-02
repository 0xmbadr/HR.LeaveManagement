using HR.LeaveManagement.Application.Dtos;
using HR.LeaveManagement.Application.LeaveAllocation.Dtos;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocations.Requests.Queries
{
    public class GetLeaveAllocationListRequest : IRequest<List<LeaveAllocationDto>> { }
}
