using System.Text.Json.Serialization;

using MM.API.Extensions;
using MM.API.Middlewares;
using MM.CrossCutting.Dependencies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
.AddJsonOptions(options =>
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter())
);


builder.Services.AddDependencies(builder.Configuration);
builder.Services.AddAppRateLimiter();

var app = builder.Build();

await app.ApplySeeds();

app.UseRouting();
app.MapControllers();

app.UseRateLimiter();
app.UseAuthentication();
app.UseAuthorization();
app.UseMiddleware<ExceptionHandler>();

app.Run();
