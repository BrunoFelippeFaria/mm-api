using System.Threading.RateLimiting;

using Microsoft.AspNetCore.RateLimiting;

using MM.API.Extensions;
using MM.API.Middlewares;
using MM.CrossCutting.Dependencies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDependencies(builder.Configuration);

builder.Services.AddAppRateLimiter();

var app = builder.Build();

app.UseRouting();
app.MapControllers();

app.UseRateLimiter();
app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<ExceptionHandler>();


app.Run();
