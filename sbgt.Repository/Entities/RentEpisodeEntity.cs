namespace sbgt.Repository.Entities;

public class RentEpisodeEntity 
    : BaseEntity
{
    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }

    public ItemEntity Item { get; set; } = null!;
    public MemberEntity Rentee { get; set; } = null!;
}