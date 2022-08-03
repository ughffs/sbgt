namespace sbgt.ClientModel.Summaries;

public class ItemSummary
{
    public Guid Id { get; set; }
    
    public List<RentEpisodeSummary> RentEpisodes { get; set; }
}