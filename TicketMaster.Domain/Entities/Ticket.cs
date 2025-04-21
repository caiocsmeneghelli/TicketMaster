using TicketMaster.Domain.Enums;

namespace TicketMaster.Domain.Entities
{
    public class Ticket
    {
        public Guid Guid { get; private set; }
        public MovieSession MovieSession { get; private set; }
        public string Seat { get; private set; }
        public Payment Payment { get; private set; }
        public ETicketStatus TicketStatus { get; private set; }

        public Ticket(MovieSession movieSession, string seat, Payment payment)
        {
            Guid = new Guid();
            Payment = payment;
            MovieSession = movieSession;
            Seat = seat.ToUpper();
            TicketStatus = ETicketStatus.Pending;
        }
    }
}
