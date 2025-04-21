using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketMaster.Domain.Enums
{
    public enum EPaymentType
    {
        Cash = 1,
        CreditCard = 2,
        DebitCard = 3,
        Pix = 4,
        BankSlip = 5,
        BankTranfer = 6
    }
}
