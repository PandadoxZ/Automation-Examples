namespace BoaConstrictorSpecFlow.Specs.Steps;

using Boa.Constrictor.Screenplay;
using Boa.Constrictor.WebDriver;
using BoaConstrictorSpecFlow.Specs.Interactions;
using BoaConstrictorSpecFlow.Specs.Pages;

[Binding]
public sealed class SearchDuckDuckGoSteps
{
    private readonly IActor actor;
    private string searchTerm;

    public SearchDuckDuckGoSteps(IActor actor)
    {
        this.actor = actor;
    }

    [Given(@"I am on the Duck Duck Go homepage")]
    public void GivenIAmOnTheDuckDuckGoHomepage()
    {
        actor.AttemptsTo(Navigate.ToUrl(DuckDuckGoSearchPage.Url));
    }

    [When(@"I search for ""(.*)""")]
    public void WhenISearchFor(string searchTerm)
    {
        this.searchTerm = searchTerm;
        actor.AttemptsTo(SearchDuckDuckGo.For(searchTerm));
    }

    [Then(@"I should see the search results page")]
    public void ThenIShouldSeeTheSearchResultsPage()
    {
        actor.AskingFor(Title.OfPage()).Should().Be($"{searchTerm} at DuckDuckGo");
    }
}
