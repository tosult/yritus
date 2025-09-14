using System.Net;
using AngleSharp.Html.Dom;
using Microsoft.AspNetCore.Mvc.Testing;
using Tests.Helpers;
using Xunit.Abstractions;

namespace Tests.Integration;

public class TasumiseViisTests : IClassFixture<CustomWebAppFactory<Program>>
{
    private readonly HttpClient _client;
    private readonly CustomWebAppFactory<Program> _factory;
    private readonly ITestOutputHelper _testOutputHelper;
    
    public TasumiseViisTests(CustomWebAppFactory<Program> factory, ITestOutputHelper testOutputHelper) {
        _factory = factory;
        _testOutputHelper = testOutputHelper;
        _client = factory.CreateClient(new WebApplicationFactoryClientOptions
        {
            AllowAutoRedirect = false
        });
    }

    [Fact(DisplayName = "GET - check tasumiseviisid loads")]
    public async Task DefaultPageTest()
    {
        var response = await _client.GetAsync("/TasumiseViisid");
        
        response.EnsureSuccessStatusCode();
        _testOutputHelper.WriteLine(await response.Content.ReadAsStringAsync());
    }

    [Fact(DisplayName = "POST - add new tasumiseviis")]
    public async Task AddNewTest()
    {
        var response = await _client.GetAsync("/TasumiseViisid/Create");
        response.EnsureSuccessStatusCode();
        _testOutputHelper.WriteLine(await response.Content.ReadAsStringAsync());

        var getTestContent = await HtmlHelpers.GetDocumentAsync(response);
        var form = (IHtmlFormElement)getTestContent.QuerySelector("form")!;
        
        Assert.Equal("/TasumiseViisid/Create", form.Action);
        
        var requestVerificationToken = (IHtmlInputElement) getTestContent
            .QuerySelector("input[name=\"__RequestVerificationToken\"]")!;

        var viisNimetus = "Sularaha";

        var formValues = new Dictionary<string, string> 
        {
            ["ViisNimetus"] = viisNimetus,
            
            ["__RequestVerificationToken"] = requestVerificationToken.Value,
        };

        var postRegisterResponse = await _client.PostAsync("/TasumiseViisid/Create",
            new FormUrlEncodedContent(formValues));
        
        Assert.Equal(HttpStatusCode.Found, postRegisterResponse.StatusCode);
        
        var indexResponse = await _client.GetAsync(postRegisterResponse.Headers.Location);
        indexResponse.EnsureSuccessStatusCode();
        
        var indexHtml = await indexResponse.Content.ReadAsStringAsync();
        var decoded = WebUtility.HtmlDecode(indexHtml);
        
        Assert.Contains(viisNimetus, decoded);
        _testOutputHelper.WriteLine(await indexResponse.Content.ReadAsStringAsync());
    }
}