namespace sbgt.ClientModel.Summaries;

public class RentEpisodeSummary
{
    public Guid Id { get; set; }
    
    public MemberSummary Rentee { get; set; }
}