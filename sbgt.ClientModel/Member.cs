using sbgt.ClientModel.Summaries;

namespace sbgt.ClientModel;

public class Member
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string EmailAddress { get; set; } = null!;
    public string PrimaryContactNumber { get; set; } = null!;
    public string? SecondaryContactNumber { get; set; }
    public IEnumerable<ItemSummary>? Items { get; set; }
}