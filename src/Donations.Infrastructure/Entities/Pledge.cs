using System.ComponentModel.DataAnnotations.Schema;

namespace Donations.Infrastructure.Entities;

public class Pledge 
{
    public int Id { get; set; } 
    //[ForeignKey("Donor")]
    public int DonorId { get; set; } 
    public Donor Donor { get; set; } = null!;
    public DateTime PledgeDate { get; set; }
    public decimal Amount { get; set; }
    //public List<PledgePayment> PledgesPayments { get; } = [];
    public IList<Payment> Payments { get; set; } = [];
    

    //public bool ActiveStatus { get; set; }
    //public DateTime LastPayment { get; set; }
    //public Guid CharityContact { get; set; }
    //public Guid BestowedProject { get; set; }
}