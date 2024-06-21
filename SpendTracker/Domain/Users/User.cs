 
using SpendTracker.Domain.Journies;
using SpendTracker.Domain.Primitives;
using System.ComponentModel.DataAnnotations;

namespace SpendTracker.Domain.Users
{
    public class User : Entity<Guid>
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string? Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastLoginDate { get; set; }
        public ICollection<Journey> Journeys { get; set; }

        public User() : base(Guid.NewGuid()) { }

        public User(string name, string username, string password, string? email = default)
            : base(Guid.NewGuid())
        {
            Name = name;
            UserName = username;
            Password = password;
            Email = email;
        }

       

        

    }
}
