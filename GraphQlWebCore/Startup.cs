using GraphQL.Server;
using GraphQL.Types;
using GraphQlWebCore.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQlWebCore
{
    public class Startup
    {
        private readonly IHostingEnvironment _env;

        public Startup(IHostingEnvironment env)
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
                .AddMvcCore()
                .AddJsonFormatters();

            services.AddRegistration();

            // Add GraphQL services and configure options
            services.AddGraphQL(options =>
            {
                options.ExposeExceptions = _env.IsDevelopment();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();


            app.UseStaticFiles();

            // the route is just for the intro page - it is not required for the graphql service
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            // use HTTP middleware for Schema at path /graphql
            app.UseGraphQL<ISchema>("/graphql");
        }
    }
}
