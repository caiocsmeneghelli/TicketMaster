using TicketMaster.Domain.Enums;

namespace TicketMaster.Domain.Entities
{
    public class Payment
    {
        public Payment(EPaymentType paymentType)
        {
            Guid = new Guid();
            PaymentType = paymentType;
            PaymentStatus = (paymentType == EPaymentType.Cash || paymentType == EPaymentType.Pix) ?
                EPaymentStatus.Approved : EPaymentStatus.Pending;
        }

        public Guid Guid { get; private set; }
        public DateTime? FinishedProcess { get; private set; }
        public EPaymentType PaymentType { get; private set; }
        public EPaymentStatus PaymentStatus { get; private set; }
        public Ticket Ticket { get; private set; }

        public void Cancel()
        {
            PaymentStatus = EPaymentStatus.Canceled;
            FinishedProcess = DateTime.Now;
        }
    }
}
