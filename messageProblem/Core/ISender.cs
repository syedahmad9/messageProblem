using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace messageProblem.Core
{
    internal interface ISender
    {
        public void Send(string recipient, string message);
    }
}
