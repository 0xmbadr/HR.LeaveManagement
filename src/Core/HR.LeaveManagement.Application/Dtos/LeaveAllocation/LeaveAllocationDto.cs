using HR.LeaveManagement.Application.Dtos.Common;
using HR.LeaveManagement.Application.LeaveType.Dtos;

namespace HR.LeaveManagement.Application.LeaveAllocation.Dtos
{
    public class LeaveAllocationDto : BaseDto
    {
        public int NumberOfDays { get; set; }
        public int LeaveTypeId { get; set; }
        public LeaveTypeDto LeaveType { get; set; }
        public int Period { get; set; }
    }
}
