using HR.LeaveManagement.MVC.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace HR.LeaveManagement.MVC.Controllers
{
    [Route("[controller]")]
    public class LeaveTypesController : Controller
    {
        public ILeaveTypeService _leaveTypeService;

        public LeaveTypesController(ILeaveTypeService leaveTypeService)
        {
            _leaveTypeService = leaveTypeService;
        }

        public async Task<IActionResult> Index()
        {
            var models = await _leaveTypeService.GetLeaveTypes();
            return View(models);
        }
    }
}
