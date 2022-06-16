using ProjetoLocadoraAPI.Context;
using ProjetoLocadoraAPI.Repositories;
using ProjetoLocadoraAPI.Repositories.Interfaces;
using ProjetoLocadoraAPI.Services;
using ProjetoLocadoraAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var sqliteConnectionString = builder.Configuration.GetConnectionString("Sqlite");
builder.Services.AddDbContext<PLocadoraDBContext>(opt => opt.UseSqlite(sqliteConnectionString));

builder.Services.AddScoped<InfClienteService, ClienteService>();
builder.Services.AddScoped<InfFilmeService, FilmeService>();
builder.Services.AddScoped<InfLocacaoService, LocacaoService>();

builder.Services.AddScoped<InfClienteRepository, ClienteRepository>();
builder.Services.AddScoped<InfFilmeRepository, FilmeRepository>();
builder.Services.AddScoped<InfLocacaoRepository, LocacaoRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
