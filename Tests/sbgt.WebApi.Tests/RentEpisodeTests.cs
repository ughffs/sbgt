using System.Net.Http.Json;
using FluentAssertions;
using sbgt.ClientModel;

namespace sbgt.WebApi.Tests;

public class RentEpisodeTests : TestSetup
{
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

    [Test]
    public async Task GivenThereAreRentEpisodes_WhenRequestingByMemberId_ThenOnlyGetTheEpisodesForThatMember()
    {
        // ARRANGE
        // Get member number 3, as in the test data they have a rent episode against them
        Guid memberId = TestData.Members.ElementAt(2).Id;
        
        var request = new HttpRequestMessage()
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri($"/RentEpisode/Member/{memberId}", UriKind.Relative)
        };
        
        // ACT
        var response = await client.SendAsync(request);
        var responseObject = await response.Content
            .ReadFromJsonAsync<List<RentEpisode>>();

        // ASSERT
        response.IsSuccessStatusCode
            .Should()
            .BeTrue();
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

    [Test]
    public async Task GivenThereAreRentEpisodes_WhenRequestingByEpisodeId_ThenGetOnlyThatEpisode()
    {
        // ARRANGE
        // Get member number 3, as in the test data they have a rent episode against them
        Guid episodeId = TestData.SingleRentEpisodeGuid;
        
        var request = new HttpRequestMessage()
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri($"/RentEpisode/{episodeId}", UriKind.Relative)
        };
        
        // ACT
        var response = await client.SendAsync(request);
        var responseObject = await response.Content
            .ReadFromJsonAsync<RentEpisode>();
        
        // ASSERT
        response.IsSuccessStatusCode
            .Should()
            .BeTrue();
        responseObject
            .Should()
            .BeOfType<RentEpisode>();
        responseObject?.Item
            .Should()
            .NotBeNull();
        responseObject?.Rentee
            .Should()
            .NotBeNull();
    }
    
}