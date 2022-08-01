namespace sbgt.WebApi.Tests;

public class TestSetup
{
    public HttpClient Client { get; private set; } = null!;

    [SetUp]
    public void SetUp()
    {
        Client = GlobalSetup.SandboxApplication.CreateClient();
    }
    
}