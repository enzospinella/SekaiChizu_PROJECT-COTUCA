using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using projeto_pratica_api.Data;

namespace projeto_pratica_api
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
            /*services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:5001", "http://localhost:8080")
                        .WithMethods("POST","PUT","DELETE","GET");
                    });
            });*/
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllHeaders",
                        builder =>
                    {
                            builder.AllowAnyOrigin()
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                        });
            });

            services.AddDbContext<MapaMundiContext>(
                x => x.UseSqlServer(Configuration.GetConnectionString("StringConexaoSQLServer"))
            );
            services.AddControllers();
            services.AddScoped<IRepositoryMM_Paises, RepositoryMM_Paises>();
            services.AddScoped<IRepositoryMM_Usuario, RepositoryMM_Usuario>(); 
            services.AddScoped<IRepositoryDadosG, RepositoryDadosG>(); 
            services.AddScoped<IRepositoryDadosH, RepositoryDadosH>(); 
            services.AddScoped<IRepositoryHistorico, RepositoryHistorico>(); 
            services.AddScoped<IRepositoryAvaliacoes, RepositoryAvaliacoes>(); 
            services.AddScoped<IRepositoryLugares, RepositoryLugares>(); 
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            };
            
            // O projeto é aberto direto em uma conexão https ||ENZO
            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            //app.UseCors(MyAllowSpecificOrigins);
            app.UseCors("AllowAllHeaders");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
