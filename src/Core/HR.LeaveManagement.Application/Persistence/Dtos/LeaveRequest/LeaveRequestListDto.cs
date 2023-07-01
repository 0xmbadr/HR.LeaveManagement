using HR.LeaveManagement.Application.Persistence.Dtos.Common;

namespace HR.LeaveManagement.Application.Persistence.Dtos.LeaveRequest
{
    public class LeaveRequestListDto : BaseDto
    {
        public LeaveTypeDto LeaveType { get; set; }
        public DateTime DateRequested { get; set; }
        public bool? Approved { get; set; }
    }
}
