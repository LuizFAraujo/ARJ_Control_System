using Microsoft.EntityFrameworkCore;
using Sys.API.DataDb;
using Sys.API.Models;

var builder = WebApplication.CreateBuilder(args);

// =================================================================
//Contexto criado (Banco de Dados):
builder.Services.AddDbContext<DataDbContext>(
    options => options.UseSqlite(builder.Configuration.GetConnectionString("Default")));

// =================================================================

// -------------------------------
// Toda vez que "alguém" precisar de um "IAtividadeRepo",
// passa para esse "alguém" o "AtividadeRepo".
// builder.Services.AddScoped<IAtividadeRepo, AtividadeRepo>();

// builder.Services.AddScoped<Codigo>();

// similar ...


// =================================================================


// Add services to the container.
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

// ---------------------------------------
// habilita / desabilita redirecionameto HTTPS
// app.UseHttpsRedirection();
// ---------------------------------------

app.UseAuthorization();

app.MapControllers();

app.Run();
