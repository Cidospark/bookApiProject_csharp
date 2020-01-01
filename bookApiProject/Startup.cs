using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookApiProject.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace bookApiProject
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        /*
         *************************** README ******************************
         * 
            In order for us to be able use entity framework we need to 
            create a connection string to that database, and to do that
            we need to implement IConfiguration interface. This interface allows us 
            to use the connection string stored in the appsettings.json file.
         *
        */
        public IConfiguration Configuration { get; set; }

        public Startup(IConfiguration configuration)
        {
            // This process is simply refered to => Injection Dependency
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            // define connection string
            var connectionString = Configuration["connectionStrings:bookDbConnectionString"];

            // add DbContext as a service
            services.AddDbContext<BookDBContext>(c => c.UseSqlServer(connectionString));

            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IReviewerRepository, ReviewerRepository>();
            services.AddScoped<IReviewRepository, ReviewRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, BookDBContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});

            //context.SeedDataContext();

            app.UseMvc(); 
        }
    }
}
