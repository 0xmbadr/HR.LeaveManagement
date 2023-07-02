using HR.LeaveManagement.Application.LeaveType.Dtos;

namespace HR.LeaveManagement.Application.Dtos.LeaveAllocation
{
    public interface ILeaveAllocationDto
    {
        public int NumberOfDays { get; set; }
        public int LeaveTypeId { get; set; }
        public int Period { get; set; }
    }
}
