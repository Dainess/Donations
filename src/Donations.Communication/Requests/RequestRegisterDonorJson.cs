namespace Donations.Communication.Requests;

public class RequestRegisterDonorJson
{
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public DateTime RegisteredSince { get; set; } = DateTime.UtcNow;
}