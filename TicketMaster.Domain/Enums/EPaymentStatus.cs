using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketMaster.Domain.Enums
{
    public enum EPaymentStatus
    {
        Pending = 1,
        Approved = 2,
        Declined = 3,
        Canceled = 4,
        Refounded = 5
    }
}
