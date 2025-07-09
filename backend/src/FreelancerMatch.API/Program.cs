

using FreelancerMatch.Application;
using FreelancerMatch.Infrastructure;
using FreelancerMatch.Infrastructure.Db;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// --- SEÇÃO DE CONFIGURAÇÃO DE SERVIÇOS ---

// Chama os métodos de extensão para registrar tudo de cada camada
builder.Services.AddInfrastructureLayer(builder.Configuration);
builder.Services.AddApplicationLayer();
builder.Services.AddAutoMapper(typeof(Program).Assembly);


// Adicionar outros serviços que pertencem à camada de Apresentação (API)
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// --- SEÇÃO DE CONFIGURAÇÃO DO PIPELINE HTTP ---

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (app.Environment.IsDevelopment())
{
    using (var scope = app.Services.CreateScope())
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        dbContext.Database.Migrate();
    }
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();