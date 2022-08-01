namespace sbgt.Repository.Entities;

public class Item : BaseEntity
{
    public string Name { get; set; } = null!;

    public IEnumerable<RentEpisode> RentEpisodes { get; set; } = null!;
}