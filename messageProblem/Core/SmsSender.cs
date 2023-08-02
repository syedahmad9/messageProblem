using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace messageProblem.Core
{
    public class SmsSender : ISmsSender
    {
        public void Send(string recipient, string message)
        {
            Console.WriteLine(message);
            Console.WriteLine($"SMS Sent to {recipient}");
        }
    }
}
