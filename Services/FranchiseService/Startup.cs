using FranchiseService.Commands;
using FranchiseService.Commands.Interfaces;
using FranchiseService.Mapper;
using FranchiseService.Models;
using FranchiseService.Repositories;
using FranchiseService.Validator;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace FranchiseService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IFranchiseValidator, FranchiseValidator>();

            services.AddScoped<IAsyncRepository<Franchise>, FranchiseRepo>();

            services.AddSingleton<IMapper<Franchise, FranchiseDTO>, FranchiseToFranchiseDTO>();

            services.AddTransient<IAsyncGetAllCommand<FranchiseDTO>, GetFranchisesCommand>();
            services.AddTransient<IAsyncGetByIDCommand<FranchiseDTO>, GetFranchiseByIDCommand>();
            services.AddTransient<IAsyncPostCommand<Franchise>, PostFranchiseCommand>();
            services.AddTransient<IAsyncPutCommand<Franchise>, PutFranchiseCommand>();
            services.AddTransient<IAsyncDeleteCommand<Franchise>, DeleteFranchiseCommand>();

            services.AddControllers();

            services.AddMassTransit(cfg =>
            {
                cfg.AddConsumer<FranchiseConsumer>();

                cfg.UsingRabbitMq((context, factory) =>
                {
                    factory.Host("localhost", "/", hostCfg =>
                    {
                        hostCfg.Username("guest");
                        hostCfg.Password("guest");
                    });
                    factory.ReceiveEndpoint(cfg =>
                    {
                        cfg.ConfigureConsumer<FranchiseConsumer>(context);
                    });
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
