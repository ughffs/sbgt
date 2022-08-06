namespace sbgt.Repository.Entities;

public class Member : BaseEntity 
{
    public string Name { get; set; } = null!;
    public string EmailAddress { get; set; } = null!;
    public string PrimaryContactNumber { get; set; } = null!;
    public string? SecondaryContactNumber { get; set; }
    public IEnumerable<Item>? Items { get; set; }
}