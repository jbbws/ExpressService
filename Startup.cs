using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using GrpcExpress.Grpc;
using GrpcBase;
namespace ExpressService
{
    public class Startup
    {
        private IGrpcServer _grpcServer;
        private const string GrpcUrl = @"GRPCURL";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddGrpc(Configuration.GetValue<Uri>(GrpcUrl));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,IGrpcServer grpcServer,IApplicationLifetime applicationLifetime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvc();
            _grpcServer = grpcServer;
            applicationLifetime.ApplicationStarted.Register(_grpcServer.Start);
            applicationLifetime.ApplicationStarted.Register(_grpcServer.Stop);
        }
    }
}
