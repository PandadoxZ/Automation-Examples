namespace BoaConstrictorSpecFlow.Specs.Requests;

using RestSharp;

public static class ZippopotamusRequests
{
    public static IRestRequest GetLocation(string countryCode, int zipCode) =>
        new RestRequest($"{countryCode}/{zipCode}", Method.GET);
}