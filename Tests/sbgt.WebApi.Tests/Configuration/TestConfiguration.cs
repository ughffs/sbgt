namespace sbgt.WebApi.Tests.Configuration;

public class TestConfiguration
{
    public bool OverrideWebapiConnectionString { get; set; }
    public string ConnectionString { get; set; } = null!;
}