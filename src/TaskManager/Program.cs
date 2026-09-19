using Microsoft.EntityFrameworkCore;
using TaskManager.Contracts;
using TaskManager.Interfaces;
using TaskManager.Persistence;
using TaskManager.Repositories;
using TaskManager.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TasksDbContext>(opt =>
    opt.UseNpgsql(builder.Configuration.GetConnectionString("Db")));

builder.Services.AddScoped<TaskRepository>();
builder.Services.AddScoped<TaskService>();
builder.Services.AddScoped<ITareas>(sp => sp.GetRequiredService<TaskService>());

// Interfaces consumidas → clientes HTTP hacia los otros componentes.
builder.Services.AddHttpClient<IProyectos, ProyectosHttpClient>(c =>
    c.BaseAddress = new Uri(builder.Configuration["Services:Projects"]!)); // valida proyecto abierto
builder.Services.AddHttpClient<IUsuarios, UsuariosHttpClient>(c =>
    c.BaseAddress = new Uri(builder.Configuration["Services:Users"]!));    // valida asignado

// TODO: AddAuthentication().AddJwtBearer(...) con el mismo Jwt:Secret.
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<TasksDbContext>();
    // TODO: db.Database.EnsureCreated();
}

app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.MapGet("/health", () => Results.Ok("ok"));

app.Run();
