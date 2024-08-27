namespace Donations.Infrastructure.Entities;

public class PledgePayment
{
    public int PledgeId { get; set; }
    public int PaymentId { get; set; }
    public Pledge Pledge { get; set; } = null!;
    public Payment Payment { get; set; } = null!;
}