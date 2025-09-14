using System.Net;
using AngleSharp.Html.Dom;
using Domain.App;
using Microsoft.AspNetCore.Mvc.Testing;
using Tests.Helpers;
using Xunit.Abstractions;

namespace Tests.Integration;

public class YritusTests : IClassFixture<CustomWebAppFactory<Program>>
{
    private readonly HttpClient _client;
    private readonly CustomWebAppFactory<Program> _factory;
    private readonly ITestOutputHelper _testOutputHelper;
    
    public YritusTests(CustomWebAppFactory<Program> factory, ITestOutputHelper testOutputHelper) {
        _factory = factory;
        _testOutputHelper = testOutputHelper;
        _client = factory.CreateClient(new WebApplicationFactoryClientOptions
        {
            AllowAutoRedirect = false
        });
    }

    [Fact(DisplayName = "GET - check yritused (homepage) loads")]
    public async Task DefaultPageTest()
    {
        var response = await _client.GetAsync("/");
        
        response.EnsureSuccessStatusCode();
        _testOutputHelper.WriteLine(await response.Content.ReadAsStringAsync());
    }

    [Fact(DisplayName = "POST - add new yritus")]
    public async Task AddNewTest()
    {
        var response = await _client.GetAsync("/Yritused/Create");
        response.EnsureSuccessStatusCode();
        _testOutputHelper.WriteLine(await response.Content.ReadAsStringAsync());

        var getTestContent = await HtmlHelpers.GetDocumentAsync(response);
        var form = (IHtmlFormElement)getTestContent.QuerySelector("form")!;
        
        Assert.Equal("/Yritused/Create", form.Action);
        
        var requestVerificationToken = (IHtmlInputElement) getTestContent
            .QuerySelector("input[name=\"__RequestVerificationToken\"]")!;

        var nimi = "Raju möll";
        var beginning = DateTime.Now.AddDays(1).ToString("yyyy-MM-ddTHH:mm");
        var ending = DateTime.Now.AddDays(2).ToString("yyyy-MM-ddTHH:mm");
        var asukoht = "Vabaduse väljak, Tallinn";

        var formValues = new Dictionary<string, string> 
        {
            ["Nimi"] = nimi,
            ["Algus"] = beginning,
            ["Lopp"] = ending,
            ["Asukoht"] = asukoht,
            
            ["__RequestVerificationToken"] = requestVerificationToken.Value,
        };
        
        /*
        _testOutputHelper.WriteLine(nimi);
        _testOutputHelper.WriteLine(beginning);
        _testOutputHelper.WriteLine(ending);
        _testOutputHelper.WriteLine(asukoht);
        */

        var postRegisterResponse = await _client.PostAsync("/Yritused/Create",
            new FormUrlEncodedContent(formValues));
        // var postRegisterResponse = await _client.SendAsync(form, formValues);
        
        Assert.Equal(HttpStatusCode.Found, postRegisterResponse.StatusCode);
        
        var indexResponse = await _client.GetAsync(postRegisterResponse.Headers.Location);
        indexResponse.EnsureSuccessStatusCode();
        
        var indexHtml = await indexResponse.Content.ReadAsStringAsync();
        var decoded = WebUtility.HtmlDecode(indexHtml);
        // _testOutputHelper.WriteLine(indexHtml);
        
        Assert.Contains(nimi, decoded);
        _testOutputHelper.WriteLine(await indexResponse.Content.ReadAsStringAsync());
    }
}