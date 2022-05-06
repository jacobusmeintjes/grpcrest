namespace helloworld.sdk.Services.Contracts;

public interface IHelloWorldService
{
    Task<string> SayHello(string name);
}