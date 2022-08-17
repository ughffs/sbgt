using System.Net.Http.Json;
using FluentAssertions;
using sbgt.ClientModel;

namespace sbgt.WebApi.Tests;

public class RentEpisodeTests : TestSetup
{
    //public HttpClient client { get; private set; } = null!;
    
    //[SetUp]
    //public void SetUp()
    //{
    //    client = GlobalSetup.SandboxApplication.CreateClient();
    //}
    
    [Test]
    public async Task GivenThereAreRentEpisodes_WhenRequestingAll_ThenAllShouldBeReturned()
    {
        // ARRANGE
        var request = new HttpRequestMessage()
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri($"/RentEpisode/all", UriKind.Relative)
        };

        // ACT
        var response = await client.SendAsync(request);
        var responseObject = await response.Content
            .ReadFromJsonAsync<List<RentEpisode>>();
        
        // ASSERT
        response.IsSuccessStatusCode
            .Should()
            .Be(true);
        responseObject?.Count
            .Should()
            .NotBe(0);
        responseObject
            .Should()
            .BeOfType<List<RentEpisode>>();
        responseObject?[0].Item
            .Should()
            .NotBeNull();
        responseObject?[0].Rentee
            .Should()
            .NotBeNull();
    }
    
}