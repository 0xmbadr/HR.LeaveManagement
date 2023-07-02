using AutoMapper;
using HR.LeaveManagement.Application.Dtos.LeaveRequest;
using HR.LeaveManagement.Application.Features.LeaveRequests.Requests.Queries;
using HR.LeaveManagement.Application.Contracts.Persistence;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequests.Handlers.Queries
{
    public class GetLeaveRequestListRequestHandler
        : IRequestHandler<GetLeaveRequestListRequest, List<LeaveRequestDto>>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;

        public GetLeaveRequestListRequestHandler(
            ILeaveRequestRepository leaveRequestRepository,
            IMapper mapper
        )
        {
            _mapper = mapper;
            _leaveRequestRepository = leaveRequestRepository;
        }

        public async Task<List<LeaveRequestDto>> Handle(
            GetLeaveRequestListRequest request,
            CancellationToken cancellationToken
        )
        {
            var leaveRequests = await _leaveRequestRepository.GetLeaveRequestsWithDetails();

            return _mapper.Map<List<LeaveRequestDto>>(leaveRequests);
        }
    }
}
