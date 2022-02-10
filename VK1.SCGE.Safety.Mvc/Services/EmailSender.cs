using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VK1.SCGE.Safety.Mvc.Services {
    public class EmailSender : IEmailSender {
        public Task SendEmailAsync(string email, string subject, string message) {
            return Task.CompletedTask;
        }
    }
}
