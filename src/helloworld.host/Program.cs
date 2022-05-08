using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using helloworld.host.Clients;
using helloworld.sdk;
using helloworld.sdk.Services.Contracts;
using Microsoft.Extensions.DependencyInjection;

BenchmarkRunner.Run<BenchmarkClients>();


[HtmlExporter]//, SimpleJob(launchCount: 1, warmupCount: 1, targetCount: 10, invocationCount: 10000)]
public class BenchmarkClients
{

    [Params(100, 200, 1000)] public int IterationCount;
    
    private readonly RestClient _restClient = new RestClient();
    private readonly GrpcClient _grpcClient = new GrpcClient();

    [Benchmark]
    public async Task RestGetAsync()
    {
        for (int i = 0; i < IterationCount; i++)
        {
            await _restClient.SendHello();
        }
    }

    [Benchmark]
    public async Task GrpcGetAsync()
    {
        for (int i = 0; i < IterationCount; i++)
        {
            await _grpcClient.SendHello();
        }
    }
}

[MemoryDiagnoser, SimpleJob(launchCount: 1, warmupCount: 1, targetCount: 10, invocationCount: 10000)]
public class Benchmark
{
    private readonly GrpcBenchmark _grpcBenchmark = new GrpcBenchmark();
    private readonly RestBenchmark _restBenchmark = new RestBenchmark();
    
    
    [BenchmarkDotNet.Attributes.Benchmark]
    public async  Task GrpcBenchmark()
    {
        await _grpcBenchmark.SendNameAsync("Grpc");
    }

    [BenchmarkDotNet.Attributes.Benchmark]
    public async Task RestBenchmark()
    {
        await _restBenchmark.SendNameAsync("Rest");
    }
}

public class GrpcBenchmark
{
    private readonly IHelloWorldService _helloWorldService;
    public GrpcBenchmark()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddHelloWorld(new HelloWorldOptions(HelloWorldType.Grpc));

        var provider = serviceCollection.BuildServiceProvider();

        _helloWorldService = provider.GetRequiredService<IHelloWorldService>();
    }

    public async Task SendNameAsync(string name)
    {
        await _helloWorldService.SayHello(name);
    }


}

public class RestBenchmark
{
    private readonly IHelloWorldService _helloWorldService;
    public RestBenchmark()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddHelloWorld(new HelloWorldOptions(HelloWorldType.Rest));

        var provider = serviceCollection.BuildServiceProvider();

        _helloWorldService = provider.GetRequiredService<IHelloWorldService>();

    }

    public async Task SendNameAsync(string name)
    {
        await _helloWorldService.SayHello(name);
    }
}