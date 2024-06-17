using SpendTracker.Domain.Primitives;

namespace SpendTracker.Domain.Users
{
    public class User : Entity<Guid>
    {

        public string Name { get; set; }
        public string? Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }

        public User()
       : base(Guid.NewGuid()) { }

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
