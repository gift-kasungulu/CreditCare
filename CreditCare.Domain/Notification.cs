using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCare.Domain
{
    public class Notification
    {
        public int NotificationId { get; set; }
        public string Message { get; set; }
        public DateTime SentDate { get; set; }
        public bool IsSms { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }

}
