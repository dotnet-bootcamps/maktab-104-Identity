using Microsoft.AspNetCore.Identity.UI.Services;

namespace IdentitySample.CS.Identity.Infrastructures
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            return Task.CompletedTask;
        }
    }
}
