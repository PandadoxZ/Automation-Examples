namespace BoaConstrictorSpecFlow.Specs.Pages;

using Boa.Constrictor.WebDriver;
using OpenQA.Selenium;
using static Boa.Constrictor.WebDriver.WebLocator;

public static class DuckDuckGoSearchPage
{
    public static string Url => "https://duckduckgo.com/";
    public static IWebLocator SearchInput => L("Search Input", By.Id("search_form_input_homepage"));
    public static IWebLocator SearchButton => L("Search Button", By.Id("search_button_homepage"));
}

