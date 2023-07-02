using HR.LeaveManagement.Application.LeaveAllocation.Dtos;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocations.Requests.Commands
{
    public class CreateLeaveAllocationCommand : IRequest<int>
    {
        public LeaveAllocationDto LeaveAllocationDto { get; set; }
    }
}
