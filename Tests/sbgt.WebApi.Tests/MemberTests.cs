using System.Net.Http.Json;
using FluentAssertions;
using sbgt.ClientModel;
using sbgt.ClientModel.Summaries;

namespace sbgt.WebApi.Tests;

public class MemberTests : TestSetup
{
    [Test]
    public async Task GivenThereAreMembers_WhenRequestingAll_ThenAllShouldBeReturned()
    {
        // ARRANGE
        var request = new HttpRequestMessage()
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri($"/Member/all", UriKind.Relative)
        };

        // ACT
        var response = await client.SendAsync(request);
        var responseObject = await response.Content
            .ReadFromJsonAsync<List<MemberSummary>>();
        
        // ASSERT
        response.IsSuccessStatusCode
            .Should()
            .Be(true);
        responseObject?.Count
            .Should()
            .NotBe(0);
        responseObject
            .Should()
            .BeOfType<List<MemberSummary>>();
    }

    [Test]
    public async Task GivenThereAreMembers_WhenRequestingByMemberId_ThenOnlyGetThatMember()
    {
        // ARRANGE
        // Get member number 3, as in the test data they have a rent episode against them
        Guid memberId = TestData.Members.ElementAt(2).Id;
        
        var request = new HttpRequestMessage()
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri($"Member/{memberId}", UriKind.Relative)
        };
        
        // ACT
        var response = await client.SendAsync(request);
        var responseObject = await response.Content
            .ReadFromJsonAsync<Member>();

        // ASSERT
        response.IsSuccessStatusCode
            .Should()
            .BeTrue();
        responseObject
            .Should()
            .BeOfType<Member>();
        responseObject?.Items
            .Should()
            .NotBeNull();
    }
    
}