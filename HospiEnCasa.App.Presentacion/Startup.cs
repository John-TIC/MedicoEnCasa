using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using HospiEnCasa.App.Persistencia;

namespace HospiEnCasa.App.Presentacion
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
            services.AddRazorPages();

            // Servicio IRespositorioPaciente 
            // services.AddSingleton<IRepositorioPaciente>(new RepositorioPaciente(new HospiEnCasa.App.Persistencia.AppContext()));
            // Servicio IRespositorioFamiliarDesignado
            // services.AddSingleton<IRepositorioFamiliarDesignado>(new RepositorioFamiliarDesignado(new HospiEnCasa.App.Persistencia.AppContext()));

            services.AddScoped<IRepositorioPaciente>((IServiceProvider sp) => new RepositorioPaciente(new Persistencia.AppContext()));

            services.AddScoped<IRepositorioFamiliarDesignado>((IServiceProvider sp) => new RepositorioFamiliarDesignado(new Persistencia.AppContext()));

            services.AddScoped<IRepositorioMedico>((IServiceProvider sp) => new RepositorioMedico(new Persistencia.AppContext()));

            services.AddScoped<IRepositorioEnfermera>((IServiceProvider sp) => new RepositorioEnfermera(new Persistencia.AppContext()));

            services.AddScoped<IRepositorioSugerenciaCuidado>((IServiceProvider sp) => new RepositorioSugerenciaCuidado(new Persistencia.AppContext()));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => endpoints.MapRazorPages());
        }
    }
}
