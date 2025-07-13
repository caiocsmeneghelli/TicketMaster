using TicketMaster.Domain.ValueObjects;

namespace TicketMaster.Domain.Entities
{
    public class User
    {
        public int Id { get; private set; }
        public string? FirstName { get; private set; }
        public string? LastName { get; private set; }
        public bool Active { get; private set; }
        public string Email { get; private set; }
        public string PasswordHash { get; private set; }

        public User()
        {
            
        }

        public User(string? firstName, string? lastName, string email, string passwordHash)
        {
            FirstName = firstName;
            LastName = lastName;
            Active = true;
            Email = email;
            PasswordHash = passwordHash;
        }
    }
}
