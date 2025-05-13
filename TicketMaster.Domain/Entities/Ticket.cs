using TicketMaster.Domain.Enums;

namespace TicketMaster.Domain.Entities
{
    public class Ticket
    {
        public Guid Guid { get; private set; }
        public Guid GuidMovieSession { get; private set; }
        public MovieSession MovieSession { get; private set; }
        public string? Seat { get; private set; }
        public ETicketStatus TicketStatus { get; private set; }

        public Guid GuidOrderRequest { get; private set; }
        public OrderRequest OrderRequest { get; private set; }
        //public User? Usuario { get; private set; }

        public Ticket(Guid guidMovieSession, string? seat, Guid guidOrderRequest)
        {
            Guid = Guid.NewGuid();
            GuidMovieSession = guidMovieSession;
            Seat = seat?.ToUpper();
            TicketStatus = ETicketStatus.Pending;
            GuidOrderRequest = guidOrderRequest;
        }

        public void Cancel()
        {
            TicketStatus = ETicketStatus.Canceled;
        }
    }
}
