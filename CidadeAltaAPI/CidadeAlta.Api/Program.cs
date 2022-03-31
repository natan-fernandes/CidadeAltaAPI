using CidadeAlta.Data;
using CidadeAlta.Domain.Models;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddFluentValidation(x => 
        x.RegisterValidatorsFromAssemblyContaining<Entity>());

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CidadeAltaContext>(options =>
{
    var connectionString = builder.Configuration["dbContextSettings:ConnectionString"];
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

builder.Services.AddRouting(options => options.LowercaseUrls = true);

InjetarDependencias(builder);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();

#region Injeção de dependências
void InjetarDependencias(WebApplicationBuilder builder)
{

}
#endregion