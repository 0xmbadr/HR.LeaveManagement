using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Commands
{
    public class DeleteLeaveRequestCommand : IRequest
    {
        public int Id { get; set; }
    }
}
