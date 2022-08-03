using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace sbgt.WebApi.Tests;

public class InitialTests //: TestSetup
{
    public HttpClient client { get; private set; } = null!;
    
    [SetUp]
    public void SetUp()
    {
        client = GlobalSetup.SandboxApplication.CreateClient();
    }
    
    [Test]
    public async Task Get_All_Items_Should_Succeed()
    {
        // ARRANGE
        var request = new HttpRequestMessage()
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri($"/Item/all", UriKind.Relative)
        };

        // ACT
        var response = await client.SendAsync(request);
        
        // ASSERT
        response.IsSuccessStatusCode
            .Should()
            .Be(true);
    }
    
    [Test]
    public async Task Get_Member_By_Guid_Should_Succeed()
    {
        // ARRANGE
        var member = await GlobalSetup.SandboxApplication.Context.Members.FirstOrDefaultAsync();
        
        var request = new HttpRequestMessage()
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri($"/Member/{member.Id}", UriKind.Relative)
        };

        // ACT
        var response = await client.SendAsync(request);
        
        // ASSERT
        response.IsSuccessStatusCode
            .Should()
            .Be(true);
    }
}