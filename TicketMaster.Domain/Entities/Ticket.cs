using TicketMaster.Domain.Enums;

namespace TicketMaster.Domain.Entities
{
    public class Ticket
    {
        public Guid Guid { get; private set; }
        public Guid GuidMovieSession { get; private set; }
        public MovieSession MovieSession { get; private set; }
        public string? Seat { get; private set; }
        public Guid GuidPayment { get; private set; }
        public Payment Payment { get; private set; }
        public ETicketStatus TicketStatus { get; private set; }

        public User? Usuario { get; private set; }

        public Ticket(Guid guidMovieSession, string? seat, Guid guidPayment)
        {
            Guid = new Guid();
            GuidPayment = guidPayment;
            GuidMovieSession = guidMovieSession;
            Seat = seat?.ToUpper();
            TicketStatus = ETicketStatus.Pending;
        }

        public void Cancel()
        {
            TicketStatus = ETicketStatus.Canceled;
        }
    }
}
