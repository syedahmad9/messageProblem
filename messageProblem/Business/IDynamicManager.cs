using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace messageProblem.Business
{
    internal interface IDynamicManager
    {
        public void BroadCast(List<Recipient> recipients, string message);

    }
    
}
