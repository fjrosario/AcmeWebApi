using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Data.Types
{
    public enum OrderStatusType
    {
        Unknown = 0,
        Pending,
        Processing,
        Shipped,
        Delivered,
        Canceled
    }
}
