using sbgt.Repository.Context;
using sbgt.WebApi.Tests.WebApplicationFactory;
using NUnit.Framework;
using Microsoft.Extensions.Configuration;

namespace sbgt.WebApi.Tests;

[SetUpFixture]
public class GlobalSetup
{

    public static TestConfiguration TestConfiguration { get; private set; } = null!;
    public static SandboxApplication SandboxApplication { get; private set; } = null!;

    [OneTimeSetUp]
    public void Setup()
    {
        TestConfiguration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false)
            .Build()
            .Get<TestConfiguration>();

        SandboxApplication = new SandboxApplication(TestConfiguration);
        SandboxApplication.CreateClient();

        var result = sbgt.MigrationRunner.Program.Main(Array.Empty<string>());
        Assert.That(result, Is.EqualTo(0));

        SandboxApplication.Context.SeedTestData();
    }
    
    [OneTimeTearDown]
    public void TearDown()
    {
        if(TestConfiguration.OverrideWebapiConnectionString) // Only delete if running tests on isolated db
            SandboxApplication.Context.Database.EnsureDeleted();
    }
}