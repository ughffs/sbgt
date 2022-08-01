namespace sbgt.Repository.Entities;

public class RentEpisode 
    : BaseEntity
{
    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }

    public Item Item { get; set; }
}