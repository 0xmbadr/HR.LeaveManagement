using AutoMapper;
using HR.LeaveManagement.Application.Dtos.LeaveRequest.Validators;
using HR.LeaveManagement.Application.Dtos.LeaveType.Validators;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Features.LeaveRequests.Requests.Commands;
using HR.LeaveManagement.Application.Contracts.Persistence;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequests.Handlers.Commands
{
    public class UpdateLeaveRequestCommandHandler : IRequestHandler<UpdateLeaveRequestCommand, Unit>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public UpdateLeaveRequestCommandHandler(
            ILeaveRequestRepository leaveRequestRepository,
            ILeaveTypeRepository leaveTypeRepository,
            IMapper mapper
        )
        {
            _leaveRequestRepository = leaveRequestRepository;
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(
            UpdateLeaveRequestCommand request,
            CancellationToken cancellationToken
        )
        {
            var leaveRequest = await _leaveRequestRepository.Get(request.Id);

            if (request.updateLeaveRequestDto != null)
            {
                var validators = new UpdateLeaveRequestDtoValidator(_leaveTypeRepository);
                var validationResult = await validators.ValidateAsync(
                    request.updateLeaveRequestDto
                );

                if (validationResult.IsValid == false)
                    throw new ValidationException(validationResult);
                // var leaveRequest = await _leaveRequestRepository.Get(request.LeaveRequestDto.Id);

                _mapper.Map(request.updateLeaveRequestDto, leaveRequest);

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
