using System.ComponentModel.DataAnnotations.Schema;

namespace Donations.Infrastructure.Entities;

public class Donor 
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public bool ActiveStatus { get; set; } = true;
    public DateTime RegisteredSince { get; set; }
    public IList<Pledge> Pledges { get; set; } = [];
    public IList<Payment> Payments { get; set; } = [];

    //public DateTime LastPledge { get; set; }
    //public DateTime LastPayment { get; set; }
    //public Guid CharityContact { get; set; }
    //public int Age { get; set; }
    //public string Occupation { get; set; } 
    //public decimal TotalDonated { get; set; }
}