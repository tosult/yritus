using Microsoft.AspNetCore.Mvc.Testing;
using Xunit.Abstractions;
using WebApp;

namespace Tests.Integration;

public class HomeTests : IClassFixture<CustomWebAppFactory<Program>>
{
    private readonly HttpClient _client;
    private readonly ITestOutputHelper _testOutputHelper;

    public HomeTests(CustomWebAppFactory<Program> factory, ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
        _client = factory.CreateClient(new WebApplicationFactoryClientOptions
        {
            AllowAutoRedirect = false
        });
    }

    [Fact(DisplayName = "GET - check homepage loading")]
    public async Task DefaultHomePageTest()
    {
        var response = await _client.GetAsync("/");
        response.EnsureSuccessStatusCode();
        _testOutputHelper.WriteLine(await response.Content.ReadAsStringAsync());
    }
}