using helloworld.sdk.Infrastructure.Contracts;
using helloworld.sdk.Services.Contracts;

namespace helloworld.sdk.Services;

public class HelloWorldService : IHelloWorldService
{
    private readonly IHelloWorldAgent _helloWorldAgent;

    public HelloWorldService(IHelloWorldAgent helloWorldAgent)
    {
        _helloWorldAgent = helloWorldAgent;
    }
    
    public async Task<string> SayHello(string name)
    {
        return await _helloWorldAgent.SayHello(name);
    }
}