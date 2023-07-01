using HR.LeaveManagement.Application.Persistence.Dtos.Common;

namespace HR.LeaveManagement.Application.Persistence.Dtos
{
    public class LeaveTypeDto : BaseDto
    {
        public string Name { get; set; }
        public int DefaultDays { get; set; }
    }
}
