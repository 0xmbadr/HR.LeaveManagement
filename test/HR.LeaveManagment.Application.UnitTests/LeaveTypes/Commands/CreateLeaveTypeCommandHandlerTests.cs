using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Dtos.LeaveType;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Features.LeaveTypes.Handlers.Commands;
using HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
using HR.LeaveManagement.Application.LeaveType.Dtos;
using HR.LeaveManagement.Application.Profiles;
using HR.LeaveManagement.Application.Responses;
using HR.LeaveManagment.Application.UnitTests.Mocks;
using Moq;
using Shouldly;

namespace HR.LeaveManagment.Application.UnitTests.LeaveTypes.Commands
{
    public class CreateLeaveTypeCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<ILeaveTypeRepository> _mockRepo;
        private readonly CreateLeaveTypeDto _leaveTypeDto;
        private readonly CreateLeaveTypeCommandHandler _handler;

        public CreateLeaveTypeCommandHandlerTests()
        {
            _mockRepo = MockLeaveTypeRepository.GetLeaveTypeRepository();

            var mappingConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mappingConfig.CreateMapper();

            _handler = new CreateLeaveTypeCommandHandler(_mockRepo.Object, _mapper);

            _leaveTypeDto = new CreateLeaveTypeDto { DefaultDays = 15, Name = "test Dto" };
        }

        [Fact]
        public async Task ValidLeaveTypeAdded()
        {
            var result = await _handler.Handle(
                new CreateLeaveTypeCommand() { CreateLeaveTypeDto = _leaveTypeDto },
                CancellationToken.None
            );

            var leaveTypes = await _mockRepo.Object.GetAll();

            result.ShouldBeOfType<BaseCommandResponse>();
            leaveTypes.Count.ShouldBe(3);
        }

        [Fact]
        public async Task InValidLeaveTypeAdded()
        {
            _leaveTypeDto.DefaultDays = -1;

            // ValidationException ex = await Should.ThrowAsync<ValidationException>(
            //     async () =>
            //         await _handler.Handle(
            //             new CreateLeaveTypeCommand() { CreateLeaveTypeDto = _leaveTypeDto },
            //             CancellationToken.None
            //         )
            // );

            var result = await _handler.Handle(
                new CreateLeaveTypeCommand() { CreateLeaveTypeDto = _leaveTypeDto },
                CancellationToken.None
            );

            var leaveTypes = await _mockRepo.Object.GetAll();

            leaveTypes.Count.ShouldBe(2);
            result.ShouldBeOfType<BaseCommandResponse>();
            // ex.ShouldNotBeNull();
        }
    }
}
