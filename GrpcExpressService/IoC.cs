using System;
using GrpcBase;
using Microsoft.Extensions.DependencyInjection;
using GrpcExpress.Grpc;
namespace GrpcExpress.Grpc
{
    public static class IoC 
    {
        public static IServiceCollection AddGrpc(this IServiceCollection services, Uri grpcUrl)
        {
            services.Configure<GrpcServerOptions>((o)=> o.ListenAddress = grpcUrl);
            services.AddTransient<IGrpcServerService,ExpressGrpcService>();
            services.AddSingleton<IGrpcServer,GrpcServer>();
            return services;
    }
}