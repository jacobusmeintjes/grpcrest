﻿using greeter_sdk_client;
using helloworld.sdk.Infrastructure.Contracts;

namespace helloworld.sdk.Infrastructure.Agents.Grpc;

internal class HelloWorldAgentGrpc : IHelloWorldAgent
{
    private readonly Greeter.GreeterClient _client;

    public HelloWorldAgentGrpc(Greeter.GreeterClient client)
    {
        _client = client;
    }

    public async Task<string> SayHello(string name)
    {
        Console.WriteLine($"Saying Hello {name} from Grpc");

        try
        {
            var reply = await _client.SayHelloAsync(
                              new HelloRequest { Name = name });

            Console.WriteLine("Greeting from Grpc Server: " + reply.Message);

            return reply.Message;
        }
        catch(Exception e) {
            Console.WriteLine(e);
        }

        return "";
    }
}