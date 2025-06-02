using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMaster.Domain.Enums;

namespace TicketMaster.Application.ViewModels.OrderRequests
{
    public class OrderRequestViewModel
    {
        public Guid Guid { get; set; }
        public Guid GuidPayment { get; set; }
        public EPaymentStatus PaymentStatus { get; set; }
        public EPaymentType PaymentType { get; set; }
        public decimal TotalValue { get; set; }
    }
}
