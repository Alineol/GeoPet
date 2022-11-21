using Microsoft.OpenApi.Models;
using projetoFinal.db;
using projetoFinal.db.Repository;
using projetoFinal.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddHttpClient();
builder.Services.AddDbContext<Context>();
builder.Services.AddScoped<Context>();
// adiciona o repository e a service de pessoaCuidadora
builder.Services.AddScoped<PessoaCuidadoraRepository>();
builder.Services.AddScoped<PessoaCuidadoraService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => {
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "GeoPet API", Description = "Api para manipulação de dados da GeoPet", Version = "v1" });
    string file = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    string path = Path.Combine(AppContext.BaseDirectory, file);
    options.IncludeXmlComments(path);
});

using (var db = new Context()) {
    db.Database.EnsureCreated();
}

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
