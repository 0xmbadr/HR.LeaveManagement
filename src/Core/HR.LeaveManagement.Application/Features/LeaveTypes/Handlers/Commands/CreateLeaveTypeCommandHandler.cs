using AutoMapper;
using HR.LeaveManagement.Application.Dtos.LeaveType.Validators;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
using HR.LeaveManagement.Application.Contracts.Persistence;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Handlers.Commands
{
    public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, int>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public CreateLeaveTypeCommandHandler(
            ILeaveTypeRepository leaveTypeRepository,
            IMapper mapper
        )
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(
            CreateLeaveTypeCommand request,
            CancellationToken cancellationToken
        )
        {
            var validators = new CreateLeaveTypeDtoValidator();
            var validationResult = await validators.ValidateAsync(request.CreateLeaveTypeDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var leaveType = _mapper.Map<Domain.LeaveType>(request.CreateLeaveTypeDto);

            leaveType = await _leaveTypeRepository.Add(leaveType);

            return leaveType.Id;
        }
    }
}
