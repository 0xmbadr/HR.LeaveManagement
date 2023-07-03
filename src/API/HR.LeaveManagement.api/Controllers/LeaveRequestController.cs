using HR.LeaveManagement.Application.Dtos.LeaveRequest;
using HR.LeaveManagement.Application.Features.LeaveRequests.Requests.Commands;
using HR.LeaveManagement.Application.Features.LeaveRequests.Requests.Queries;
using HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HR.LeaveManagement.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LeaveRequestController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveRequestController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<LeaveRequestDto>>> Get()
        {
            var leaveRequests = await _mediator.Send(new GetLeaveRequestListRequest());

            return Ok(leaveRequests);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveRequestDto>> Get(int id)
        {
            var leaveRequests = await _mediator.Send(new GetLeaveRequestDetailRequest { Id = id });

            return Ok(leaveRequests);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateLeaveRequestDto leaveRequestDto)
        {
            var command = new CreateLeaveRequestCommand { CreateLeaveRequestDto = leaveRequestDto };
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(
            int id,
            [FromBody] UpdateLeaveRequestDto leaveRequestDto
        )
        {
            await _mediator.Send(
                new UpdateLeaveRequestCommand { Id = id, updateLeaveRequestDto = leaveRequestDto }
            );

            return NoContent();
        }

        [HttpPut("changeApproval/{id}")]
        public async Task<ActionResult> CreateApproval(
            int id,
            [FromBody] ChangeLeaveRequestApprovalDto changeLeaveRequestApprovalDto
        )
        {
            await _mediator.Send(
                new UpdateLeaveRequestCommand
                {
                    Id = id,
                    ChangeLeaveRequestApprovalDto = changeLeaveRequestApprovalDto
                }
            );

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteLeaveRequestCommand { Id = id });

            return NoContent();
        }
    }
}
