using helloworld.sdk;
using helloworld.sdk.Services.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHelloWorld(new HelloWorldOptions(HelloWorldType.Grpc));
    })
    .Build();

var myService = host.Services.GetRequiredService<IHelloWorldService>();

var response = await myService.SayHello("Test Client");


Console.WriteLine(response);
Console.WriteLine("Press any key to exit...");
Console.ReadKey();