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

    [Fact(DisplayName = "POST - add isik to yritus")]
    public async Task AddNewIsikTest()
    {
        var homeResponse = await _client.GetAsync("/");
        homeResponse.EnsureSuccessStatusCode();
        
        var home = await HtmlHelpers.GetDocumentAsync(homeResponse);

        var yritusRow = home.QuerySelectorAll("tr").Skip(1).FirstOrDefault();
        Assert.NotNull(yritusRow);
        
        var detailsLink = yritusRow.QuerySelector("a[href*='/Yritused/Details']") as IHtmlAnchorElement;
        Assert.NotNull(detailsLink);
        var yritusId = detailsLink.Href.Split('/').Last();
        // _testOutputHelper.WriteLine($"Yritus ID: {yritusId}");
        
        var addIsikLink = yritusRow.QuerySelector($"a[href*='/Isikud/Create?yritusId={yritusId}']") as IHtmlAnchorElement;
        Assert.NotNull(addIsikLink);
        
        var createIsikResponse = await _client.GetAsync(addIsikLink.Href);
        createIsikResponse.EnsureSuccessStatusCode();
        var createIsik = await HtmlHelpers.GetDocumentAsync(createIsikResponse);
        
        var form = (IHtmlFormElement)createIsik.QuerySelector("form")!;
        var requestVerificationToken = (IHtmlInputElement)createIsik
            .QuerySelector("input[name=\"__RequestVerificationToken\"]")!;
            
        var eesnimi = "Toivo";
        var perenimi = "Sults";
        var isikukood = "39108160275";
        var lisainfo = "Lisainfot ka natukene";
        var tasumiseviisid = await TasumiseViisHelper.CreateTasumiseViis(_client);

        var formValues = new Dictionary<string, string> 
        {
            ["YritusId"] = yritusId,
            ["Eesnimi"] = eesnimi,
            ["Perenimi"] = perenimi,
            ["Isikukood"] = isikukood,
            ["Lisainfo"] = lisainfo,
            ["SelectTasumiseViisId"] = tasumiseviisid.ToString(),
            
            ["__RequestVerificationToken"] = requestVerificationToken.Value,
        };
        
        var postRegisterResponse = await _client.PostAsync($"/Isikud/Create?yritusId={yritusId}",
            new FormUrlEncodedContent(formValues));
        Assert.Equal(HttpStatusCode.OK, postRegisterResponse.StatusCode);
        
        var checkYritusAfteResponse = await _client.GetAsync(postRegisterResponse.Headers.Location);
        checkYritusAfteResponse.EnsureSuccessStatusCode();
        var decoded = WebUtility.HtmlDecode(checkYritusAfteResponse.Content.ReadAsStringAsync().Result);
        
        _testOutputHelper.WriteLine(decoded);
        
        Assert.Contains(eesnimi, decoded);
        Assert.Contains(perenimi, decoded);
        
        // var indexHtml = await homeResponse.Content.ReadAsStringAsync();
        // var decoded = WebUtility.HtmlDecode(indexHtml);
        // _testOutputHelper.WriteLine(indexHtml);
    }
}