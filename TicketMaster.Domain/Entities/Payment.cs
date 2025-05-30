﻿using TicketMaster.Domain.Enums;

namespace TicketMaster.Domain.Entities
{
    public class Payment
    {
        public Payment(EPaymentType paymentType, Guid guidOrderRequest)
        {
            Guid = Guid.NewGuid();
            PaymentType = paymentType;
            GuidOrderRequest = guidOrderRequest;
            PaymentStatus = (paymentType == EPaymentType.Cash || paymentType == EPaymentType.Pix) ?
                EPaymentStatus.Approved : EPaymentStatus.Pending;
        }

        public Guid Guid { get; private set; }
        public DateTime? FinishedProcess { get; private set; }
        public EPaymentType PaymentType { get; private set; }
        public EPaymentStatus PaymentStatus { get; private set; }

        public Guid GuidOrderRequest { get; private set; }
        public OrderRequest OrderRequest { get; private set; }

        public void Cancel()
        {
            PaymentStatus = EPaymentStatus.Canceled;
            FinishedProcess = DateTime.Now;
        }
    }
}
