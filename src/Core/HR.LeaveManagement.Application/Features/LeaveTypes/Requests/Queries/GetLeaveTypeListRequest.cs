using HR.LeaveManagement.Application.Dtos;
using HR.LeaveManagement.Application.LeaveType.Dtos;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Queries
{
    public class GetLeaveTypeListRequest : IRequest<List<LeaveTypeDto>> { }
}
