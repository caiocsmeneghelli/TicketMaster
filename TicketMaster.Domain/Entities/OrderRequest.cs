namespace TicketMaster.Domain.Entities
{
    public class OrderRequest
    {
        public OrderRequest(Payment payment, List<Ticket> tickets)
        {
            Guid = new Guid();
            Payment = payment;
            Tickets = tickets;
        }

        public Guid Guid { get; private set; }
        public Payment Payment { get; private set; }
        public List<Ticket> Tickets { get; private set; }
        public decimal TotalValue { get; private set; }
    }
}