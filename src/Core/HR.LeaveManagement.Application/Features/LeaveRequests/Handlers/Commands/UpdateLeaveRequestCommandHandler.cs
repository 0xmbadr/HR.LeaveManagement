using AutoMapper;
using HR.LeaveManagement.Application.Features.LeaveRequests.Requests.Commands;
using HR.LeaveManagement.Application.Persistence.Contracts;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequests.Handlers.Commands
{
    public class UpdateLeaveRequestCommandHandler : IRequestHandler<UpdateLeaveRequestCommand, Unit>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;

        public UpdateLeaveRequestCommandHandler(
            ILeaveRequestRepository leaveRequestRepository,
            IMapper mapper
        )
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(
            UpdateLeaveRequestCommand request,
            CancellationToken cancellationToken
        )
        {
            var leaveRequest = await _leaveRequestRepository.Get(request.Id);

            if (request.LeaveRequestDto != null)
            {
                // var leaveRequest = await _leaveRequestRepository.Get(request.LeaveRequestDto.Id);

                _mapper.Map(request.LeaveRequestDto, leaveRequest);

                await _leaveRequestRepository.Update(leaveRequest);
            }
            else if (request.ChangeLeaveRequestApprovalDto != null)
            {
                // var leaveRequest = await _leaveRequestRepository.Get(request.ChangeLeaveRequestApprovalDto.Id);

                await _leaveRequestRepository.ChangeApprovalStatus(
                    leaveRequest,
                    request.ChangeLeaveRequestApprovalDto.Approved
                );
            }

            return Unit.Value;
        }
    }
}
