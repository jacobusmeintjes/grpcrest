using helloworld.sdk.Infrastructure;
using helloworld.sdk.Infrastructure.Agents.Grpc;
using helloworld.sdk.Infrastructure.Contracts;
using helloworld.sdk.Services;
using helloworld.sdk.Services.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace helloworld.sdk;

public static class StartupExtensions
{
    public static IServiceCollection AddHelloWorld(this IServiceCollection services, HelloWorldOptions options)
    {
        services.AddSingleton(options);

        if (options.HelloWorldType == HelloWorldType.Grpc)
        {
            services.AddSingleton<IHelloWorldAgent, HelloWorldAgentGrpc>();                      

            services.AddGrpcClient<greeter_sdk_client.Greeter.GreeterClient>(o => {
                o.Address = new Uri("https://localhost:7291");

             

            }).ConfigurePrimaryHttpMessageHandler(() =>
            {
                var httpHandler = new HttpClientHandler();
                // Return `true` to allow certificates that are untrusted/invalid
                httpHandler.ServerCertificateCustomValidationCallback =
                    HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
                return httpHandler;
            }); 
        }
        else
        {
            services.AddSingleton<IHelloWorldAgent, HelloWorldAgentRest>();

            services.AddHttpClient("restClient", o => {
                o.BaseAddress = new Uri("https://localhost:7291");
            });
        }

        services.AddSingleton<IHelloWorldService, HelloWorldService>();


        return services;
    }
}

public class HelloWorldOptions
{
    public HelloWorldType HelloWorldType { get; set; }

    public HelloWorldOptions(HelloWorldType helloWorldType)
    {
        HelloWorldType = helloWorldType;
    }
}

public enum HelloWorldType
{
    Grpc,
    Rest
}