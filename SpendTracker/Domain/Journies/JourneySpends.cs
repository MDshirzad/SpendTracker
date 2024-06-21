using SpendTracker.Domain.Primitives;
using SpendTracker.Domain.Spends;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpendTracker.Domain.Journies
{
    public class JourneySpends:Entity<Guid>
    {

        public JourneySpends()
      : base(Guid.NewGuid()) { }

        public int JourneySpendsId { get; set; } // Primary key

        public int JourneyId { get; set; } // Foreign key to Journey
        public decimal TotalAmount { get; set; }
        public string Currency { get; set; }

        public Journey Journey { get; set; }
        public ICollection<Spend> Spends { get; set; }





    }
}
