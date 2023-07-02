using HR.LeaveManagement.Application.Models;

namespace HR.LeaveManagement.Application.Contracts.Infra
{
    public interface IEmailSender
    {
        Task<bool> SendEmail(Email email);
    }
}
