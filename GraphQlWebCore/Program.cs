using GraphQL;
using GraphQL.Types;
using GraphQlTypes.Schemas;
using GraphQlWebCore.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.DependencyInjection;


var builder = WebApplication.CreateBuilder(args);

// add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRegistration();

// add GraphQL services and configure options
builder.Services.AddGraphQL
    (b => b
    .AddSchema<EmployeeSchema>()
    .AddSystemTextJson()
    .AddDataLoader()
    );

// kestrel
builder.Services.Configure<KestrelServerOptions>(options =>
{
    options.AllowSynchronousIO = true;
});

var app = builder.Build();

// configure the HTTP request pipeline.
app.UseStaticFiles();
app.UseRouting();

// the route is just for the intro page - it is not required for the graphql service
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// use HTTP middleware for Schema at path /graphql
app.UseGraphQL<ISchema>("/graphql");

// use GraphQL Playground middleware at default path /ui/playground with default options
app.UseGraphQLPlayground();

app.Run();