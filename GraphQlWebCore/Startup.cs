using System;
using GraphQL.Server;
using GraphQL.Types;
using GraphQlTypes.Schemas;
using GraphQlWebCore.DependencyInjection;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace GraphQlWebCore
{
    public class Startup
    {
        private readonly IWebHostEnvironment _env;

        public Startup(IWebHostEnvironment env)
        {
            _env = env;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // just required for showing razor view after start
            services
                .AddMvc();

            services
                .AddMvcCore();

            services.AddRegistration();

            // Add GraphQL services and configure options
            services.AddGraphQL
                (options =>
                {
                    options.EnableMetrics = _env.IsDevelopment();
                    options.UnhandledExceptionDelegate = ctx => Console.WriteLine(ctx.OriginalException.Message);
                })
                .AddSystemTextJson()
                .AddDataLoader()
                .AddGraphTypes(typeof(EmployeeSchema));

            // kestrel
            services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
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
            app.UseRouting();

            // the route is just for the intro page - it is not required for the graphql service
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });

            // use HTTP middleware for Schema at path /graphql
            app.UseGraphQL<ISchema>("/graphql");
        }
    }
}
