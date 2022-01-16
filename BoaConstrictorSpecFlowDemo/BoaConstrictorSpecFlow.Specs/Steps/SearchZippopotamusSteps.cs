namespace BoaConstrictorSpecFlow.Specs.Steps;

using Boa.Constrictor.Screenplay;
using BoaConstrictorSpecFlow.Specs.Interactions;
using BoaConstrictorSpecFlow.Specs.Responses;
using RestSharp;
using System.Net;

[Binding]
public sealed class SearchZippopotamusSteps
{
    private readonly IActor actor;
    private string countryCode;
    private int zipCode;
    private IRestResponse<ZippopotamusResponse> response;

    public SearchZippopotamusSteps(IActor actor)
    {
        this.actor = actor;
    }

    [Given(@"I have the country code of (us|ca) and the zip code (\d+)")]
    public void GivenIHaveTheCountryCodeAndTheZipCode(string countryCode, int zipCode)
    {
        this.countryCode = countryCode;
        this.zipCode = zipCode;
    }

    [When(@"I search for locations? using these codes")]
    public void WhenISearchForLocationsUsingTheseCodes()
    {
        response = actor.AsksFor(ZippopotamusLocations.For(countryCode, zipCode));
    }

    [Then(@"I should see the place name (.*)")]
    public void ThenIShouldSeeThePlaceName(string expectedPlaceName)
    {
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        response.Data.Places.Count.Should().Be(1);
        response.Data.Places.First().PlaceName.Should().Be(expectedPlaceName);
    }
}
