using messageProblem.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace messageProblem.Business
{
    internal class MessageManager : IMessageManager
    {
        private readonly IEmailSender emailSender;
        private readonly IPushNotificationSender pushNotificationSender;
        private readonly ISmsSender smsSender;
        public MessageManager(IEmailSender emailSender, IPushNotificationSender pushNotificationSender, ISmsSender smsSender) { 
            this.emailSender = emailSender;
            this.pushNotificationSender = pushNotificationSender;
            this.smsSender = smsSender;
        }

        public void BroadCast(MessageModes modes, List<Recipient> recipients, string message)
        {
            foreach (var recipient in recipients)
            {
                if (modes == MessageModes.Email || modes == MessageModes.BroadCast)
                {
                    SendEmail(recipient.EmailAddress, message);
                }
                if (modes == MessageModes.PushNotification || modes == MessageModes.BroadCast)
                {
                    PushNotification(recipient.DeviceToken, message);
                }
                if (modes == MessageModes.Sms || modes == MessageModes.BroadCast)
                {
                    SendSms(recipient.PhoneNumber, message);
                }
            }
        }

        private void PushNotification(string recipient, string message)
        {
            pushNotificationSender.Send(recipient, message);
        }

        private void SendEmail(string recipient, string message)
        {
             emailSender.Send(recipient, message);
        }

        private void SendSms(string recipient, string message)
        {
            smsSender.Send(recipient, message);
        }
    }
}
