namespace Donations.Communication.Responses;

public class ResponseShortDonorJson
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public bool ActiveStatus { get; set; } 
}