using Application;
using Infrastructure;
using RESTApi;
using RESTApi.Middleware;

var builder = WebApplication.CreateBuilder(args);


// Configure project dependency
{
    var config = builder.Configuration;
    builder.Services
        .AddRESTApiServer()
        .AddApplication()
        .AddInfrastructure(config);
}

{
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
}

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.Run();
