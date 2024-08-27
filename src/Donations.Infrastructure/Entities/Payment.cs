namespace Donations.Infrastructure.Entities;

public class Payment
{
    public int Id { get; set; } 
    public int DonorId { get; set; } 
    public Donor Donor { get; set; } = null!;
    public DateTime PaymentDate { get; set; }
    public decimal Amount { get; set; }
    //public List<PledgePayment> PledgesPayments { get; } = [];
    public List<Pledge> Pledges { get; } = [];

    //public Guid BestowedProject { get; set; }
    //public bool IsPeriodic { get; set; }
}