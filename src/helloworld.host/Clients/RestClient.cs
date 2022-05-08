using System.Net.Http.Headers;

namespace helloworld.host.Clients;

public class RestClient
{
    private static readonly HttpClient _client = new HttpClient();

    public async Task<string> SendHello()
    {
        _client.DefaultRequestHeaders.Clear();
        _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        
        var response = await _client.GetAsync("https://localhost:7291/helloworld?name=Test");
        return await response.Content.ReadAsStringAsync();
    } 
}