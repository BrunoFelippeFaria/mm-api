using MM.CrossCutting.Dependencies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDependencies(builder.Configuration);

var app = builder.Build();

app.UseRouting();
app.MapControllers();

app.Run();
