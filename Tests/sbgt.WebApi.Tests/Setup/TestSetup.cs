namespace sbgt.WebApi.Tests;

public class TestSetup
{
    public HttpClient client { get; private set; } = null!;

    [SetUp]
    public void SetUp()
    {
        client = GlobalSetup.SandboxApplication.CreateClient();
    }
    
}