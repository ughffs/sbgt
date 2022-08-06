namespace sbgt.ClientModel.Summaries;

public class ItemSummary
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public MemberSummary Owner { get; set; } = null!;
}