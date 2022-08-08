using sbgt.ClientModel.Summaries;

namespace sbgt.ClientModel;

public class RentEpisode
{
    public Guid Id { get; set; }
    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }

    public ItemSummary Item { get; set; } = null!;
    public MemberSummary Rentee { get; set; } = null!;
}