using Microsoft.EntityFrameworkCore;
using UserManager.Auth;
using UserManager.Interfaces;
using UserManager.Persistence;
using UserManager.Repositories;
using UserManager.Services;

var builder = WebApplication.CreateBuilder(args);

// ── Persistencia: base propia del componente (PostgreSQL) ────────────────────
builder.Services.AddDbContext<UsersDbContext>(opt =>
    opt.UseNpgsql(builder.Configuration.GetConnectionString("Db")));

// ── Composición de dependencias (interfaces → implementaciones) ──────────────
builder.Services.AddScoped<UserRepository>();
builder.Services.AddSingleton<JwtTokenIssuer>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<IUsuarios>(sp => sp.GetRequiredService<UserService>());
builder.Services.AddScoped<IAutenticacion>(sp => sp.GetRequiredService<UserService>());

// ── Autenticación stateless (validación local del JWT con el secreto) ────────
// TODO: configurar AddAuthentication().AddJwtBearer(...) leyendo Jwt:Secret/Issuer/Audience.
builder.Services.AddAuthentication(/* JwtBearerDefaults.AuthenticationScheme */);
builder.Services.AddAuthorization();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Para la demo: crea el esquema si no existe (en producción se usarían migraciones).
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<UsersDbContext>();
    // TODO: db.Database.EnsureCreated();  (o db.Database.Migrate())
}

app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.MapGet("/health", () => Results.Ok("ok")); // usado por el gateway / healthchecks

app.Run();
