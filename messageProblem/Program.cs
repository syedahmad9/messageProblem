using messageProblem.Business;
using messageProblem.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace messageProblem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            IConfiguration config = builder.Build();

            var serviceProvider = new ServiceCollection()
                .AddSingleton<IEmailSender, EmailSender>()
                .AddSingleton<IPushNotificationSender, PushNotificationSender>()
                .AddSingleton<ISmsSender, SmsSender>()
                .AddSingleton<IMessageManager, MessageManager>()
                .AddSingleton<IDynamicManager, DynamicManager>()
                .AddSingleton<IConfiguration>(config)
                .BuildServiceProvider();

            Console.WriteLine("Please select from following options");
            

            var messageManager = serviceProvider.GetService<IDynamicManager>();

            List<Recipient> recipients = new List<Recipient>() {
                new Recipient("user1@email.com", "923131345234", "00fc13adff785122b4ad28809a3420982341241421348097878e577c991de8f0") ,
                new Recipient("user2@email.com", "923131344123", "00fc13adff785122b4ad28809a3420982341241421348097878e577c991de8f0")
            };

            messageManager?.BroadCast(recipients, "Hello, World!");
        }
        static void Main2(string[] args)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            IConfiguration config = builder.Build();

            var serviceProvider = new ServiceCollection()
                .AddSingleton<IEmailSender, EmailSender>()
                .AddSingleton<IPushNotificationSender, PushNotificationSender>()
                .AddSingleton<ISmsSender, SmsSender>()
                .AddSingleton<IMessageManager, MessageManager>()
                .BuildServiceProvider();

            Console.WriteLine("Please select from following options");
            Console.WriteLine($"1. {MessageModes.BroadCast}");
            Console.WriteLine($"2. {MessageModes.Email}");
            Console.WriteLine($"3. {MessageModes.PushNotification}");
            Console.WriteLine($"4. {MessageModes.Sms}");
            bool validInput;
            short mode;

            do {
                var input = Console.ReadLine();
                validInput = short.TryParse(input, out mode);
                if (!validInput || mode < 1 || mode > 4)
                    Console.WriteLine("Please provide valid value");
            } while (!validInput || mode < 1 || mode > 4);


            var messageManager = serviceProvider.GetService<IMessageManager>();

            List<Recipient> recipients = new List<Recipient>() { 
                new Recipient("user1@email.com", "923131345234", "00fc13adff785122b4ad28809a3420982341241421348097878e577c991de8f0") ,
                new Recipient("user2@email.com", "923131344123", "00fc13adff785122b4ad28809a3420982341241421348097878e577c991de8f0")
            };

            messageManager?.BroadCast((MessageModes)mode, recipients, "Hello, World!");
        }
    }
}