namespace sbgt.ClientModel;

public class RentEpisode
{
    public Guid Id { get; set; }
    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }

    public Item Item { get; set; } = null!;
    public Member Rentee { get; set; } = null!;
}