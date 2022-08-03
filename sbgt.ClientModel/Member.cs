namespace sbgt.ClientModel;

public class Member
{
    public string Name { get; set; } = null!;
    public string EmailAddress { get; set; } = null!;
    public string PrimaryContactNumber { get; set; } = null!;
    public string? SecondaryContactNumber { get; set; } = null!;
}