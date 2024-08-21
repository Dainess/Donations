namespace Donations.Infrastructure.Entities;

public class Pledge 
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Donor Donor{ get; set; } = null!;
    public Guid DonorId { get; set; } 
    public DateTime PledgeDate { get; set; }
    public decimal Amount { get; set; }
    //public List<PledgePayment> PledgesPayments { get; } = [];
    public List<Payment> Payments { get; } = [];
    

    //public bool ActiveStatus { get; set; }
    //public DateTime LastPayment { get; set; }
    //public Guid CharityContact { get; set; }
    //public Guid BestowedProject { get; set; }
}