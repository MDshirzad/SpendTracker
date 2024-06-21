using SpendTracker.Domain.Primitives;
using SpendTracker.Domain.Users;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SpendTracker.Domain.Journies
{
    public class Journey : Entity<Guid>
    {
        public int JourneyId { get; set; } // Primary key

        public int UserId { get; set; } // Foreign key to User
        public string JourneyName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public User User { get; set; }
        public JourneySpends JourneySpends { get; set; }

        public Journey() : base(Guid.NewGuid()) { }

        


        public Journey(string jouneyName,DateTime startDate,DateTime endDate) : base(Guid.NewGuid())
        {
            JourneyName = jouneyName;
            StartDate = startDate;
            EndDate = endDate;
           
        }

        
    }
}
