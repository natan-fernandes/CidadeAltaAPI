using System.Reflection;
using System.Text;
using CidadeAlta.Application.Application;
using CidadeAlta.Application.AutoMapper;
using CidadeAlta.Application.Interfaces;
using CidadeAlta.Data;
using CidadeAlta.Data.Repositories;
using CidadeAlta.Domain.Interfaces.Repositories;
using CidadeAlta.Domain.Interfaces.Services;
using CidadeAlta.Domain.Services;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddFluentValidation(x =>
        x.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    x.IncludeXmlComments(xmlPath);
});

builder.Services.AddDbContext<CidadeAltaContext>(options =>
{
    var connectionString = builder.Configuration["dbContextSettings:ConnectionString"];
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddCors();

var key = Encoding.ASCII.GetBytes(builder.Configuration["JWT:Token"]);
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

InjetarDependencias(builder);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.MapControllers();

app.Run();

#region Injeção de dependências
void InjetarDependencias(WebApplicationBuilder wab)
{
    wab.Services.AddScoped<IAuthService, AuthService>();
    wab.Services.AddScoped<IAuthAppService, AuthAppService>();

    wab.Services.AddScoped<IUserRepository, UserRepository>();
    wab.Services.AddScoped<IUserAppService, UserAppService>();
    wab.Services.AddScoped<IUserService, UserService>();

    wab.Services.AddScoped<ICriminalCodeService, CriminalCodeService>();
    wab.Services.AddScoped<ICriminalCodeAppService, CriminalCodeAppService>();
    wab.Services.AddScoped<ICriminalCodeRepository, CriminalCodeRepository>();
    
    wab.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
}
#endregion