namespace BoaConstrictorSpecFlow.Specs.Interactions;

using Boa.Constrictor.Screenplay;
using Boa.Constrictor.WebDriver;
using BoaConstrictorSpecFlow.Specs.Pages;

public class SearchDuckDuckGo : ITask
{
    public string Phrase { get; }

    private SearchDuckDuckGo(string phrase) =>
        Phrase = phrase;

    public static SearchDuckDuckGo For(string phrase) =>
        new SearchDuckDuckGo(phrase);

    public void PerformAs(IActor actor)
    {
        actor.AttemptsTo(SendKeys.To(DuckDuckGoSearchPage.SearchInput, Phrase));
        actor.AttemptsTo(Click.On(DuckDuckGoSearchPage.SearchButton));
    }
}
