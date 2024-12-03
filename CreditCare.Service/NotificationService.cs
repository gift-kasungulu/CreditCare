using ClientManagementSystem.Services;
using CreditCare.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCare.Services
{
    public class NotificationService
    {
        private readonly ApplicationDbContext _context;
        private readonly SmsService _smsService;

        public NotificationService(ApplicationDbContext context, SmsService smsService)
        {
            _context = context;
            _smsService = smsService;
        }

        public async Task NotifyDueDateAsync(int customerId, string message)
        {
            var notification = new Notification
            {
                CustomerId = customerId,
                Message = message,
                SentDate = DateTime.Now,
                IsSms = true
            };

            _context.Notifications.Add(notification);
            await _context.SaveChangesAsync();

            //await _smsService.SendSmsAsync(customerId, message); // SMS sending logic
        }
    }

}
