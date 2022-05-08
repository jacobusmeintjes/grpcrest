using greeter_sdk_client;
using Grpc.Net.Client;

namespace helloworld.host.Clients;

public class GrpcClient
{
    private readonly GrpcChannel _channel;
    private readonly Greeter.GreeterClient _client;

    public GrpcClient()
    {
        AppContext.SetSwitch(
            "System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
        _channel = GrpcChannel.ForAddress("https://localhost:7291");
        _client = new Greeter.GreeterClient(_channel);
    }

    public async Task<string> SendHello()
    {
        return (await _client.SayHelloAsync(new HelloRequest
        {
            Name = "Test"
        })).Message;
    }
}