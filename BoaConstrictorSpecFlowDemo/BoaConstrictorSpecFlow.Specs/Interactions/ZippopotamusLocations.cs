namespace BoaConstrictorSpecFlow.Specs.Interactions;

using Boa.Constrictor.RestSharp;
using Boa.Constrictor.Screenplay;
using BoaConstrictorSpecFlow.Specs.Requests;
using BoaConstrictorSpecFlow.Specs.Responses;
using RestSharp;

public class ZippopotamusLocations : IQuestion<IRestResponse<ZippopotamusResponse>>
{
    public string CountryCode { get; }

    public int ZipCode { get; }

    private ZippopotamusLocations(string countryCode, int zipCode)
    {
        CountryCode = countryCode;
        ZipCode = zipCode;
    }

    public static ZippopotamusLocations For(string countryCode, int zipCode) =>
        new ZippopotamusLocations(countryCode, zipCode);

    public IRestResponse<ZippopotamusResponse> RequestAs(IActor actor)
    {
        return actor.Calls(Rest.Request<ZippopotamusResponse>(ZippopotamusRequests.GetLocation(CountryCode, ZipCode)));
    }
}