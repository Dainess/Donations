using System.ComponentModel.DataAnnotations.Schema;

namespace Donations.Infrastructure.Entities;

public class Donor 
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public bool ActiveStatus { get; set; } = true;
    public IList<Payment> Payments = [];
    public IEnumerable<Pledge> Pledges = new List<Pledge>();

    //public DateTime RegisteredSince { get; set; }
    //public DateTime LastPledge { get; set; }
    //public DateTime LastPayment { get; set; }
    //public Guid CharityContact { get; set; }
    //public int Age { get; set; }
    //public string Occupation { get; set; } 
    //public decimal TotalDonated { get; set; }
}