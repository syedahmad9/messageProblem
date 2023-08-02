using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace messageProblem.Core
{
    public class PushNotificationSender : IPushNotificationSender
    {
        public PushNotificationSender() { 
            
        }
        public void Send(string recipient, string message)
        {
            Console.WriteLine(message);
            Console.WriteLine($"Push Notification Sent {recipient}");
        }
    }
}
