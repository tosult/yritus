using System.Net;
using AngleSharp.Html.Dom;

namespace Tests.Helpers;

public class TasumiseViisHelper
{
    public static async Task<Guid> CreateTasumiseViis(HttpClient client)
    {
        var response = await client.GetAsync($"/TasumiseViisid/Create");
        response.EnsureSuccessStatusCode();

        var tasumiseviisid = await HtmlHelpers.GetDocumentAsync(response);
        
        var form = (IHtmlFormElement)tasumiseviisid.QuerySelector("form")!;
        var requestVerificationToken = (IHtmlInputElement)tasumiseviisid
            .QuerySelector("input[name=\"__RequestVerificationToken\"]")!;
        
        var tasumiseViis = "Suleraha";
        var formValues = new Dictionary<string, string>
        {
            ["ViisNimetus"] = tasumiseViis,
            
            ["__RequestVerificationToken"] = requestVerificationToken.Value,
        };
        
        var postResponse = await client.PostAsync(form.Action, new FormUrlEncodedContent(formValues));
        Assert.Equal(HttpStatusCode.Found, postResponse.StatusCode);

        var homeAgain = await HtmlHelpers.GetDocumentAsync(await client.GetAsync("/TasumiseViisid"));
        
        var tasumiseViisRow = homeAgain.QuerySelectorAll("tr").Skip(1).FirstOrDefault();
        var detailsLink = tasumiseViisRow.QuerySelector("a[href*='/TasumiseViisid/Details']") as IHtmlAnchorElement;
        Assert.NotNull(detailsLink);
        var id = detailsLink.Href.Split('/').Last();
        
        return Guid.Parse(id);
    }
}