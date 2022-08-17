using System.Net.Http.Json;
using FluentAssertions;
using sbgt.ClientModel;
using sbgt.ClientModel.Summaries;

namespace sbgt.WebApi.Tests;

public class ItemTests : TestSetup
{
    [Test]
    public async Task GivenThereAreItems_WhenRequestingAll_ThenAllShouldBeReturned()
    {
        // ARRANGE
        var request = new HttpRequestMessage()
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri($"/Item/all", UriKind.Relative)
        };

        // ACT
        var response = await client.SendAsync(request);
        var responseObject = await response.Content
            .ReadFromJsonAsync<List<ItemSummary>>();
        
        // ASSERT
        response.IsSuccessStatusCode
            .Should()
            .Be(true);
        responseObject?.Count
            .Should()
            .NotBe(0);
        responseObject
            .Should()
            .BeOfType<List<ItemSummary>>();
    }

    [Test]
    public async Task GivenThereAreItems_WhenRequestingByItemId_ThenOnlyGetThatMember()
    {
        // ARRANGE
        // Get member number 3, as in the test data they have a rent episode against them
        Guid itemId = TestData.Items.ElementAt(0).Id;
        
        var request = new HttpRequestMessage()
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri($"Item/{itemId}", UriKind.Relative)
        };
        
        // ACT
        var response = await client.SendAsync(request);
        var responseObject = await response.Content
            .ReadFromJsonAsync<Item>();

        // ASSERT
        response.IsSuccessStatusCode
            .Should()
            .BeTrue();
        responseObject
            .Should()
            .BeOfType<Item>();
    }
    
}