using AutoMapper;
using HR.LeaveManagement.Application.Dtos.LeaveAllocation;
using HR.LeaveManagement.Application.Dtos.LeaveAllocation.Validators;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Features.LeaveAllocations.Requests.Commands;
using HR.LeaveManagement.Application.Contracts.Persistence;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocations.Handlers.Commands
{
    public class UpdateLeaveAllocationCommandHandler : IRequestHandler<UpdateLeaveAllocationCommand>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public UpdateLeaveAllocationCommandHandler(
            ILeaveAllocationRepository leaveAllocationRepository,
            ILeaveTypeRepository leaveTypeRepository,
            IMapper mapper
        )
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(
            UpdateLeaveAllocationCommand request,
            CancellationToken cancellationToken
        )
        {
            var validators = new UpdateLeaveAllocationDtoValidator(_leaveTypeRepository);
            var validationResult = await validators.ValidateAsync(request.UpdateLeaveAllocationDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var leaveAllocation = await _leaveAllocationRepository.Get(
                request.UpdateLeaveAllocationDto.Id
            );

            _mapper.Map(request.UpdateLeaveAllocationDto, leaveAllocation);

            await _leaveAllocationRepository.Update(leaveAllocation);

            return Unit.Value;
        }
    }
}
