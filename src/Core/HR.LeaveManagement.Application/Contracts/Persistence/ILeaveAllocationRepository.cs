using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Application.Contracts.Persistence
{
    public interface ILeaveAllocationRepository : IGenericRepository<Domain.LeaveAllocation>
    {
        Task<Domain.LeaveAllocation> GetLeaveAllocationWithDetails(int id);
        Task<List<Domain.LeaveAllocation>> GetLeaveAllocationsWithDetails();
    }
}
