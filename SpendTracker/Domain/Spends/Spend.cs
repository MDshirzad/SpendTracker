using SpendTracker.Domain.Journies;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CSharpFunctionalExtensions;

namespace SpendTracker.Domain.Spends
{
    public class Spend:Entity<Guid>
    {
        

        public Spend()
  : base(Guid.NewGuid()) { }

        public int SpendId { get; set; }
        public int JourneySpendsId { get; set; }
        public DateTime SpendDate { get; set; }
        public decimal Amount { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public JourneySpends JourneySpends { get; set; }


    }
}
