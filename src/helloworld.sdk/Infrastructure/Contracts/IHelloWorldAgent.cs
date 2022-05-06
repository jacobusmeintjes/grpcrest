namespace helloworld.sdk.Infrastructure.Contracts;

public interface IHelloWorldAgent
{
    Task<string> SayHello(string name);
}