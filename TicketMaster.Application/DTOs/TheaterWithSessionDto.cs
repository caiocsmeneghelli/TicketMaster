namespace TicketMaster.Application.DTOs
{
    public class TheaterWithSessionDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<MovieSessionGuidTimeDto> Sessions { get; set; } = new();
    }
}