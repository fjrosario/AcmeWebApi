using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Domain.Tests
{
    public static class Constants
    {
        static Constants()
        {
            BadIds = new [] { -1, -99, -100, -1001 };
        }
        public static readonly int[] BadIds;
    }
}
