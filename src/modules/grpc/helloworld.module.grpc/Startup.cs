using helloworld.module.grpc.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace helloworld.module.grpc
{
    public static class Startup
    {
        public static void AddHelloWorldGrpc(this IServiceCollection services)
        {
            services.AddGrpc();
        }

        public static void UseHelloWorldGrpc(this WebApplication app)
        {
            app.MapGrpcService<GreeterService>();
        }
    }
}
