using AutoMapper;
using HR.LeaveManagement.Application.Dtos.LeaveRequest.Validators;
using HR.LeaveManagement.Application.Features.LeaveRequests.Requests.Commands;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Responses;
using MediatR;
using HR.LeaveManagement.Application.Contracts.Infra;
using HR.LeaveManagement.Application.Models;

namespace HR.LeaveManagement.Application.Features.LeaveRequests.Handlers.Commands
{
    public class CreateLeaveRequestCommandHandler
        : IRequestHandler<CreateLeaveRequestCommand, BaseCommandResponse>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IEmailSender _emailSender;
        private readonly IMapper _mapper;

        public CreateLeaveRequestCommandHandler(
            ILeaveRequestRepository leaveRequestRepository,
            ILeaveTypeRepository leaveTypeRepository,
            IEmailSender emailSender,
            IMapper mapper
        )
        {
            _leaveRequestRepository = leaveRequestRepository;
            _leaveTypeRepository = leaveTypeRepository;
            _emailSender = emailSender;
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

            var email = new Email
            {
                To = "employee@email.com",
                Body =
                    $"Your leave request from {request.CreateLeaveRequestDto.StartDate:D} to {request.CreateLeaveRequestDto.EndDate:D} has been submitted successfully!",
                Subject = "Leave Request Submitted"
            };

            try
            {
                await _emailSender.SendEmail(email);
            }
            catch (Exception ex)
            {
                // TODO: Log or handle error.
            }

            return response;
        }
    }
}
