using sbgt.ClientModel.Summaries;

namespace sbgt.ClientModel;

public class Item
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;

    public List<RentEpisodeSummary> RentEpisodes { get; set; } = null!;
    public MemberSummary Owner { get; set; } = null!;
}