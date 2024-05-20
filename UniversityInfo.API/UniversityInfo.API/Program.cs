using UniversityInfo.Infrastructure;
using Microsoft.EntityFrameworkCore;
using UniversityInfo.Services.Aggregates;
using UniversityInfo.Services.Implements;
using AutoMapper;
using UniversityInfo.Services.Helper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<UniversityInfoContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("UniversityInfoConnectionString"), null), ServiceLifetime.Scoped);
var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});
IMapper mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddTransient<IUniversityInformationService, UniversityInformationService>();
builder.Services.AddTransient<IUniversityDomainService, UniversityDomainService>();
builder.Services.AddTransient<IWebPagesService, WebPagesService>();
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
app.UseCors(options =>
{
    options.AllowAnyHeader();
    options.AllowAnyOrigin();
    options.AllowAnyMethod();
});
app.UseAuthorization();

app.MapControllers();

app.Run();
