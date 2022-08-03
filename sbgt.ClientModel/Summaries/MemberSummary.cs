namespace sbgt.ClientModel.Summaries;

public class MemberSummary
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string EmailAddress { get; set; } = null!;
    public string PrimaryContactNumber { get; set; } = null!;
    public string? SecondaryContactNumber { get; set; } = null!;
}