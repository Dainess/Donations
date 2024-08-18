using Donations.Infrastructure.Enums;

namespace Donations.Infrastructure.Entities;

public class Change 
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string TableName { get; set; } = string.Empty;
    public Guid RecordId { get; set; }
    public DateTime TimeOfLog { get; set; }
    public string ChangeDescription { get; set;} = string.Empty;
    public ChangeType TypeOfChange { get; set; }
}