using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Services.Commands.BookCommands;
using Services.Commands.HeroCommands;
using Services.Commands.Interfaces;
using Services.Commands.MovieCommands;
using Services.Commands.UserCommands;
using Services.Mappers;
using Services.Models;
using Services.Repositories;
using Services.Validators;
using System;
using System.Collections.Generic;

namespace Services
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
            services.AddMemoryCache();

            services.AddSingleton<List<string>>();
            services.AddSingleton<List<int>>();

            services.AddScoped<IRepository<Book>, BookRepo>();
            services.AddScoped<IAsyncRepository<Hero>, HeroRepo>();
            services.AddScoped<IRepository<User>, UserRepo>();
            services.AddScoped<IAsyncRepository<Movie>, MovieRepo>();

            services.AddSingleton<IUserValidator, UserValidator>();
            services.AddSingleton<IBookValidator, BookValidator>();
            services.AddSingleton<IHeroValidator, HeroValidator>();
            services.AddSingleton<IMovieValidator, MovieValidator>();

            services.AddSingleton<IMapper<User, UserDTO>, UserToUserDTO>();
            services.AddSingleton<IMapper<Book, BookDTO>, BookToBookDTO>();
            services.AddSingleton<IMapper<Hero, HeroDTO>, HeroToHeroDTO>();
            services.AddSingleton<IMapper<Movie, MovieDTO>, MovieToMovieDTO>();

            services.AddTransient<IGetAllCommand<UserDTO>, GetUsersCommand>();
            services.AddTransient<IGetByIDCommand<UserDTO>, GetUserByIDCommand>();
            services.AddTransient<IPostCommand<User>, PostUserCommand>();
            services.AddTransient<IPutCommand<User>, PutUserCommand>();
            services.AddTransient<IDeleteCommand<User>, DeleteUserCommand>();

            services.AddTransient<IGetAllCommand<BookDTO>, GetBooksCommand>();
            services.AddTransient<IGetByIDCommand<BookDTO>, GetBookByIDCommand>();
            services.AddTransient<IPostCommand<Book>, PostBookCommand>();
            services.AddTransient<IPutCommand<Book>, PutBookCommand>();
            services.AddTransient<IDeleteCommand<Book>, DeleteBookCommand>();

            services.AddTransient<IAsyncGetAllCommand<HeroDTO>, GetHeroesCommand>();
            services.AddTransient<IAsyncGetByIDCommand<HeroDTO>, GetHeroByIDCommand>();
            services.AddTransient<IAsyncPostCommand<Hero>, PostHeroCommand>();
            services.AddTransient<IAsyncPutCommand<Hero>, PutHeroCommand>();
            services.AddTransient<IAsyncDeleteCommand<Hero>, DeleteHeroCommand>();

            services.AddTransient<IAsyncGetAllCommand<MovieDTO>, GetMoviesCommand>();
            services.AddTransient<IAsyncGetByIDCommand<MovieDTO>, GetMovieByIDCommand>();
            services.AddTransient<IAsyncPostCommand<Movie>, PostMovieCommand>();
            services.AddTransient<IAsyncPutCommand<Movie>, PutMovieCommand>();
            services.AddTransient<IAsyncDeleteCommand<Movie>, DeleteMovieCommand>();

            services.AddControllers();

            services.AddMassTransit(cfg =>
            {
                cfg.UsingRabbitMq((context, factory) =>
                {
                    factory.Host("localhost", "/", hostCfg =>
                    {
                        hostCfg.Username("guest");
                        hostCfg.Password("guest");
                    });
                });
                cfg.AddRequestClient<FranchiseRequest>(new Uri("rabbitmq://localhost/getfranchise"));
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
