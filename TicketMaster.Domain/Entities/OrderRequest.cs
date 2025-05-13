namespace TicketMaster.Domain.Entities
{
    public class OrderRequest
    {
        public OrderRequest(decimal totalValue, Guid guidPayment)
        {
            Guid = Guid.NewGuid();
            TotalValue = totalValue;
            GuidPayment = guidPayment;
        }

        public Guid Guid { get; private set; }
        public Guid GuidPayment { get; private set; }
        public Payment Payment { get; private set; }
        public List<Ticket> Tickets { get; private set; }
        public decimal TotalValue { get; private set; }
    }
}