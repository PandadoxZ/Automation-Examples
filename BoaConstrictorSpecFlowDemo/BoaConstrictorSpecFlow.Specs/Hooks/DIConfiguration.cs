namespace BoaConstrictorSpecFlow.Specs.Hooks;

using Boa.Constrictor.Logging;
using Boa.Constrictor.RestSharp;
using Boa.Constrictor.Screenplay;
using Boa.Constrictor.WebDriver;
using OpenQA.Selenium.Chrome;

[Binding]
public sealed class DIConfiguration
{
    private readonly ScenarioContext scenarioContext;

    public DIConfiguration(ScenarioContext scenarioContext)
    {
        this.scenarioContext = scenarioContext;
    }

    [BeforeScenario("web", Order = 0)]
    public void RegisterDIForWebTests()
    {
        IActor actor = new Actor("WebTester", new ConsoleLogger());
        actor.Can(BrowseTheWeb.With(new ChromeDriver()));

        scenarioContext.ScenarioContainer.RegisterInstanceAs(actor);
    }

    [AfterScenario("web")]
    public void CleanUpWebTests()
    {
        var actor = scenarioContext.ScenarioContainer.Resolve<IActor>();
        actor.AttemptsTo(QuitWebDriver.ForBrowser());
    }

    [BeforeScenario("api", Order = 0)]
    public void RegisterDIForAPITests()
    {
        IActor actor = new Actor("ApiTester", new ConsoleLogger());
        actor.Can(CallRestApi.At("http://api.zippopotam.us/"));

        scenarioContext.ScenarioContainer.RegisterInstanceAs(actor);
    }
}