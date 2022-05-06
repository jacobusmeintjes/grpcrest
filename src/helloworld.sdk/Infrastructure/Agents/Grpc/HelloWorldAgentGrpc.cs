using helloworld.sdk.Infrastructure.Contracts;

namespace helloworld.sdk.Infrastructure;

internal class HelloWorldAgentGrpc : IHelloWorldAgent
{
    public async Task SayHello(string name)
    {
        Console.WriteLine($"Saying Hello {name} from Grpc");
    }
}