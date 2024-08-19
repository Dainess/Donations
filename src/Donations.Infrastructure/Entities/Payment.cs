namespace Donations.Infrastructure.Entities;

public class Payment
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid DonorId { get; set; } 
    public DateTime PaymentDate { get; set; }
    public decimal Amount { get; set; }
    //public List<PledgePayment> PledgesPayments { get; } = [];
    public List<Pledge> Pledges { get; } = [];

    //public Guid BestowedProject { get; set; }
    //public bool IsPeriodic { get; set; }
}