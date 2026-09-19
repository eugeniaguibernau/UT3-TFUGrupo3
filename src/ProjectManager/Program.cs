using Microsoft.EntityFrameworkCore;
using ProjectManager.Contracts;
using ProjectManager.Interfaces;
using ProjectManager.Persistence;
using ProjectManager.Repositories;
using ProjectManager.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ProjectsDbContext>(opt =>
    opt.UseNpgsql(builder.Configuration.GetConnectionString("Db")));

builder.Services.AddScoped<ProjectRepository>();
builder.Services.AddScoped<IProyectos, ProjectService>();

// Interfaz consumida IUsuarios → cliente HTTP hacia UserManager (valida dueño).
builder.Services.AddHttpClient<IUsuarios, UsuariosHttpClient>(c =>
    c.BaseAddress = new Uri(builder.Configuration["Services:Users"]!));

// TODO: AddAuthentication().AddJwtBearer(...) con el mismo Jwt:Secret que UserManager.
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ProjectsDbContext>();
    // TODO: db.Database.EnsureCreated();
}

app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.MapGet("/health", () => Results.Ok("ok"));

app.Run();
