using Donations.Infrastructure.Enums;

namespace Donations.Infrastructure.Entities;

public class Change 
{
    public int Id { get; set; }
    public string TableName { get; set; } = string.Empty;
    public int RecordId { get; set; }
    public DateTime TimeOfLog { get; set; }
    public string ChangeDescription { get; set;} = string.Empty;
    public ChangeType TypeOfChange { get; set; }
    public string ChangedBy { get; set; } = string.Empty;
    //Public string TypeOfChange { get; set; }
}