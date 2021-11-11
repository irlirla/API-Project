using FranchiseService.Commands;
using FranchiseService.Commands.Interfaces;
using FranchiseService.Models;
using FranchiseService.Validator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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

            services.AddTransient<IAsyncGetAllCommand<FranchiseDTO>, GetFranchisesCommand>();
            services.AddTransient<IAsyncGetByIDCommand<FranchiseDTO>, GetFranchiseByIDCommand>();
            services.AddTransient<IAsyncPostCommand<Franchise>, PostFranchiseCommand>();
            services.AddTransient<IAsyncPutCommand<Franchise>, PutFranchiseCommand>();
            services.AddTransient<IAsyncDeleteCommand<Franchise>, DeleteFranchiseCommand>();

            services.AddControllers();
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
