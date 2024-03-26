using JWTAuth;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("ocelot.json",false,true)
    .AddEnvironmentVariables();
builder.Services.AddOcelot(builder.Configuration);

builder.Services.AddCustomJwtAuthentication();

var app = builder.Build();

//call ocelot middleware
//asynchronous
await app.UseOcelot();
app.UseAuthentication();
app.UseAuthorization();
app.Run();