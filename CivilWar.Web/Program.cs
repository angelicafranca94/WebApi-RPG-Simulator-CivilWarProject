using AutoMapper;
using CivilWar.Infra;
using CivilWar.Infra.DbContexts;
using CivilWar.Infra.Repository;
using CivilWar.Infra.Repository.Interface;
using CivilWar.Web.Services;
using CivilWar.Web.Services.Interface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
           options.UseSqlServer(builder.Configuration["MyConnectionString:DefaultConnection"]));

//Add mapping Dto with Model
IMapper mapper = MappingConfig.RegistroMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(
    AppDomain.CurrentDomain.GetAssemblies());

//Add Idependency Injection
builder.Services.AddScoped<IHeroRepository, HeroRepository>();
builder.Services.AddScoped<IBattleService, BattleService>();


// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureSwaggerGen(setup =>
{
    setup.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Civil War Project",
        Version = "v1"
    });
});

var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
