using System;
using GraphQL.Server;
using GraphQL.Types;
using GraphQlTypes.Schemas;
using GraphQlWebCore.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


var builder = WebApplication.CreateBuilder(args);

// add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRegistration();

// Add GraphQL services and configure options
builder.Services.AddGraphQL
    (options =>
    {
        options.EnableMetrics = builder.Environment.IsDevelopment();
        options.UnhandledExceptionDelegate = ctx => Console.WriteLine(ctx.OriginalException.Message);
    })
    .AddSystemTextJson()
    .AddDataLoader()
    .AddGraphTypes(typeof(EmployeeSchema));

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