using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using UserAPI.Context;
using UserAPI.Repository;

namespace UserAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            var server = Configuration["ServerName"] ?? "localhost";
            var database = Configuration["Database"] ?? "userdb";
            var user = Configuration["UserName"] ?? "cpacheco";
            var password = Configuration["Password"] ?? "cp@checo";
            Console.WriteLine("#######################################################");
            Console.WriteLine($"server: {server}");
            Console.WriteLine($"database: {database}");
            Console.WriteLine($"user: {user}");
            Console.WriteLine($"password: {password}");
            Console.WriteLine("#######################################################");



            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "My API", Version = "v1" });
            });

            var mySqlDbConnection = $"server={server};port=3306;database={database};user id={user};password={password}";

            services.AddDbContext<UsuarioDbContext>(options =>
                   options.UseMySql(mySqlDbConnection)
                );

            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Minha API .Net Core e VS Code");
            });

            app.UseMvc();
        }
    }
}
