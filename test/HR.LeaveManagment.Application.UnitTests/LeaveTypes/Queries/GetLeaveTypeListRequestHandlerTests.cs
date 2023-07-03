using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Features.LeaveTypes.Handlers.Queries;
using HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Queries;
using HR.LeaveManagement.Application.LeaveType.Dtos;
using HR.LeaveManagement.Application.Profiles;
using HR.LeaveManagment.Application.UnitTests.Mocks;
using Moq;
using Shouldly;

namespace HR.LeaveManagment.Application.UnitTests.LeaveTypes.Queries
{
    public class GetLeaveTypeListRequestHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<ILeaveTypeRepository> _mockRepo;

        public GetLeaveTypeListRequestHandlerTests()
        {
            _mockRepo = MockLeaveTypeRepository.GetLeaveTypeRepository();

            var mappingConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mappingConfig.CreateMapper();
        }

        [Fact]
        public async Task GetLeaveTypeListTest()
        {
            var handler = new GetLeaveTypeListRequestHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(
                new GetLeaveTypeListRequest(),
                CancellationToken.None
            );

            result.ShouldBeOfType<List<LeaveTypeDto>>();

            result.Count.ShouldBe(2);
        }
    }
}
