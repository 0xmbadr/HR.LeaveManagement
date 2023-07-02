using AutoMapper;
using HR.LeaveManagement.Application.Dtos.LeaveRequest.Validators;
using HR.LeaveManagement.Application.Features.LeaveRequests.Requests.Commands;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Responses;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequests.Handlers.Commands
{
    public class CreateLeaveRequestCommandHandler
        : IRequestHandler<CreateLeaveRequestCommand, BaseCommandResponse>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public CreateLeaveRequestCommandHandler(
            ILeaveRequestRepository leaveRequestRepository,
            ILeaveTypeRepository leaveTypeRepository,
            IMapper mapper
        )
        {
            _leaveRequestRepository = leaveRequestRepository;
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(
            CreateLeaveRequestCommand request,
            CancellationToken cancellationToken
        )
        {
            var response = new BaseCommandResponse();
            var validators = new CreateLeaveRequestDtoValidator(_leaveTypeRepository);
            var validationResult = await validators.ValidateAsync(request.CreateLeaveRequestDto);

            // if (validationResult.IsValid == false)
            //     throw new ValidationException(validationResult);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed!";
                response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            }

            var leaveRequest = _mapper.Map<Domain.LeaveRequest>(request.CreateLeaveRequestDto);
            leaveRequest = await _leaveRequestRepository.Add(leaveRequest);

            response.Success = true;
            response.Message = "Creation Success!";
            response.Id = leaveRequest.Id;

            return response;
        }
    }
}
