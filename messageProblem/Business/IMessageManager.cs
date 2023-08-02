using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace messageProblem.Business
{
    internal interface IMessageManager
    {
        public void BroadCast(MessageModes modes, List<Recipient> recipients, string message);

    }
    public record Recipient(string EmailAddress, string PhoneNumber, string DeviceToken);
    public enum MessageModes
    {
        BroadCast = 1,
        Email,
        PushNotification,
        Sms
    }
}
