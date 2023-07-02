using HR.LeaveManagement.Application.Persistence.Contracts;
using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Persistence.Repos
{
    public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
    {
        public LeaveTypeRepository(HrLeaveManagementDbContext dbContext)
            : base(dbContext) { }
    }
}
