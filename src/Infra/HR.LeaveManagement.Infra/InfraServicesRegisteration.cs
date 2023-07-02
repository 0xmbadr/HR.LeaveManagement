using HR.LeaveManagement.Application.Contracts.Infra;
using HR.LeaveManagement.Application.Models;
using HR.LeaveManagement.Infra.Mail;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HR.LeaveManagement.Infra
{
    public static class InfraServicesRegisteration
    {
        public static IServiceCollection ConfigureInfraServicesRegisteration(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
            services.AddTransient<IEmailSender, EmailSender>();
            return services;
        }
    }
}
