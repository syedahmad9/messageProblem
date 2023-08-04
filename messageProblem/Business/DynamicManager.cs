using messageProblem.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace messageProblem.Business
{
    internal class MessagePlugin
    {
        public string Name { get; set; }
        public string InputProperty { get; set; }
    }

    internal class DynamicManager : IDynamicManager
    {
        private readonly IConfiguration config;
        private readonly IServiceProvider serviceProvider;
        public DynamicManager(IConfiguration config, IServiceProvider serviceProvider)
        {
            this.config = config;
            this.serviceProvider = serviceProvider;
        }

        public void BroadCast(List<Recipient> recipients, string message)
        {
            var plugins = config.GetSection("MessagePlugin")
                                .Get<List<MessagePlugin>>();

            foreach (var plugin in plugins)
            {
                dynamic sender = serviceProvider.GetService(Assembly.GetExecutingAssembly().GetType(plugin.Name));

                Type t = typeof(Recipient);
                PropertyInfo prop = t.GetProperty(plugin.InputProperty);

                foreach (var recipient in recipients.Select(r=> prop.GetValue(r) as string).ToList())
                {
                    sender.Send(recipient, message);
                }
            }
        }
        
    }
}
