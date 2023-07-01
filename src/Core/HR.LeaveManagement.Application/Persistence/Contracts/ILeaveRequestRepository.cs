using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Application.Persistence.Contracts
{
    public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest> { }
}