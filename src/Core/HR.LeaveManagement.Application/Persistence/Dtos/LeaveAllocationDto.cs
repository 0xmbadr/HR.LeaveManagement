using HR.LeaveManagement.Application.Persistence.Dtos.Common;

namespace HR.LeaveManagement.Application.Persistence.Dtos
{
    public class LeaveAllocationDto : BaseDto
    {
        public int NumberOfDays { get; set; }
        public int LeaveTypeId { get; set; }
        public LeaveTypeDto LeaveType { get; set; }
        public int Period { get; set; }
    }
}
