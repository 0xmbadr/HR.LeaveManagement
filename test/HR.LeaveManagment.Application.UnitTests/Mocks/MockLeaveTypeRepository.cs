using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using Moq;

namespace HR.LeaveManagment.Application.UnitTests.Mocks
{
    public static class MockLeaveTypeRepository
    {
        public static Mock<ILeaveTypeRepository> GetLeaveTypeRepository()
        {
            var leaveTypes = new List<LeaveType>
            {
                new LeaveType
                {
                    Id = 1,
                    DefaultDays = 30,
                    Name = "test vacation"
                },
                new LeaveType
                {
                    Id = 2,
                    DefaultDays = 7,
                    Name = "test Sick"
                },
            };

            var mockRepo = new Mock<ILeaveTypeRepository>();
            mockRepo.Setup(r => r.GetAll()).ReturnsAsync(leaveTypes);

            mockRepo
                .Setup(r => r.Add(It.IsAny<LeaveType>()))
                .ReturnsAsync(
                    (LeaveType leaveType) =>
                    {
                        leaveTypes.Add(leaveType);
                        return leaveType;
                    }
                );

            return mockRepo;
        }
    }
}
