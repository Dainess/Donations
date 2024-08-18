namespace Donations.Infrastructure.Entities;

public class PledgePayment
{
    public Guid PledgeId { get; set; }
    public Guid PaymentId { get; set; }
    public Pledge Pledge { get; set; } = null!;
    public Payment Payment { get; set; } = null!;
}