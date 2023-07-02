using HR.LeaveManagement.Application.Dtos;
using HR.LeaveManagement.Application.LeaveType.Dtos;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Queries
{
    public class GetLeaveTypeDetailRequest : IRequest<LeaveTypeDto>
    {
        public int Id { get; set; }
    }
}
