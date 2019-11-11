using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore2.Models;
using BookStore2.Models.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BookStore2
{
    public class Startup
    {
        private readonly IConfiguration configuration;
        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSingleton<IBookStoreRepositories<Author>, AuthorRepository>();
            services.AddSingleton<IBookStoreRepositories<Book>, BookRepository>();
            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.AddDbContext<BookStoreDbContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString(
                    "DefaultConnection"));



                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
              
            }
            app.UseStaticFiles();
            app.UseMvc(route =>
            {
                route.MapRoute("defualt","{controller=Author}/{action=index}/{id?}");
            });
            
        }
    }
}
