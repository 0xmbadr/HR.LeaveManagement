using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
using HR.LeaveManagement.Application.Contracts.Persistence;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Handlers.Commands
{
    public class DeleteLeaveRequestCommandHandler : IRequestHandler<DeleteLeaveRequestCommand>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;

        public DeleteLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository)
        {
            _leaveRequestRepository = leaveRequestRepository;
        }

        public async Task<Unit> Handle(
            DeleteLeaveRequestCommand request,
            CancellationToken cancellationToken
        )
        {
            var leaveRequest = await _leaveRequestRepository.Get(request.Id);

            if (leaveRequest == null)
                throw new NotFoundException(nameof(leaveRequest), request.Id);

            await _leaveRequestRepository.Delete(leaveRequest);

            return Unit.Value;
        }
    }
}
