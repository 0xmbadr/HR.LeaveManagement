using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Application.Persistence.Contracts
{
    public interface ILeaveAllocationRepository : IGenericRepository<Domain.LeaveAllocation>
    {
        Task<Domain.LeaveAllocation> GetLeaveAllocationWithDetails(int id);
        Task<List<Domain.LeaveAllocation>> GetLeaveAllocationsWithDetails();
    }
}
