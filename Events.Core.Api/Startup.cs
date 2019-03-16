using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using Events.Core.Api.CQRS.Command;
using Events.Core.Api.CQRS.Command.Code;
using Events.Core.Api.CQRS.Event;
using Events.Core.Api.CQRS.Event.Code;
using Events.Core.Api.Domain.Command;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Events.Core.Api
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddScoped<ICommandBus, CommandBus>();
            services.AddScoped<IEventBus, EventBus>();
            
            // HandleCommand
            services.AddTransient<Func<Type, IHandleCommand>>(provider => key => provider.GetService<IHandleCommand>());
            services.Scan(scan =>
            {
                var assembly = Assembly.GetEntryAssembly();
                scan.FromAssemblies(assembly)
                    .AddClasses(classes => classes.AssignableTo(typeof(IHandleCommand)))
                    .AsImplementedInterfaces()
                    .WithTransientLifetime();
            }); 
            
            // Event Handle
            services.AddTransient<Func<Type, IEnumerable<IHandleEvent>>>(providers => key => providers.GetService<IEnumerable<IHandleEvent>>());
            services.Scan(scan =>
            {
                var assembly = Assembly.GetEntryAssembly();
                scan.FromAssemblies(assembly)
                    .AddClasses(classes => classes.AssignableTo(typeof(IHandleEvent)))
                    .AsImplementedInterfaces()
                    .WithTransientLifetime();
            }); 
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}