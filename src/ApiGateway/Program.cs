using ApiGateway.Auth;
using ApiGateway.Interfaces;
using ApiGateway.Routing;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient("Gateway", client => client.Timeout = Timeout.InfiniteTimeSpan)
    .ConfigurePrimaryHttpMessageHandler(() => new SocketsHttpHandler
    {
        AllowAutoRedirect = false,
        UseCookies = false,
        UseProxy = false,
        PooledConnectionLifetime = TimeSpan.FromSeconds(30)
    });
builder.Services.AddSingleton<ITokenValidator, JwtTokenValidator>();
builder.Services.AddSingleton<RouteTable>();
builder.Services.AddSingleton<IApiRest, GatewayRouter>();

var app = builder.Build();
// Verificar la configuración antes de aceptar solicitudes.
app.Services.GetRequiredService<ITokenValidator>();

app.MapGet("/health", () => Results.Ok("ok"));

// Todo lo demás pasa por el router (valida token + enruta/balancea).
app.MapFallback("/{**path}", async context =>
{
    var router = context.RequestServices.GetRequiredService<IApiRest>();
    await router.Route(context);
});

app.Run();
