namespace TicketMaster.Domain.Entities
{
    public class OrderRequest
    {
        public OrderRequest(Guid guidPayment, decimal totalValue)
        {
            Guid = new Guid();
            GuidPayment = guidPayment;
            TotalValue = totalValue;
        }

        public Guid Guid { get; private set; }
        public Guid GuidPayment { get; private set; }
        public Payment Payment { get; private set; }
        public List<Ticket> Tickets { get; private set; }
        public decimal TotalValue { get; private set; }
    }
}