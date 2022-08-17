namespace sbgt.Repository.Entities;

public class ItemEntity : BaseEntity
{
    public string Name { get; set; } = null!;

    public IEnumerable<RentEpisodeEntity> RentEpisodes { get; set; } = null!;
    public MemberEntity Owner { get; set; } = null!;
}