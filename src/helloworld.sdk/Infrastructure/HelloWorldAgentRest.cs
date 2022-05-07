using helloworld.sdk.Infrastructure.Contracts;

namespace helloworld.sdk.Infrastructure;

internal class HelloWorldAgentRest: IHelloWorldAgent
{
    private HttpClient httpClient;

    public HelloWorldAgentRest(IHttpClientFactory factory)
    {
        httpClient = factory.CreateClient("restClient");
    }

    public async Task<string> SayHello(string name)
    {
        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, $"/helloworld?name={name}");

        var response = await httpClient.SendAsync(request);

        var result = await response.Content.ReadAsStringAsync();

        return result;
    }
}