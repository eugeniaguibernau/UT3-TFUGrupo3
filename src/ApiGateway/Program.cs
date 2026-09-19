using ApiGateway.Auth;
using ApiGateway.Interfaces;
using ApiGateway.Routing;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();
builder.Services.AddSingleton<ITokenValidator, JwtTokenValidator>();
builder.Services.AddSingleton<RouteTable>();
builder.Services.AddSingleton<IApiRest, GatewayRouter>();

var app = builder.Build();

app.MapGet("/health", () => Results.Ok("ok"));

// Todo lo demás pasa por el router (valida token + enruta/balancea).
app.Run(async context =>
{
    var router = context.RequestServices.GetRequiredService<IApiRest>();
    await router.Route(context);
});

app.Run();
