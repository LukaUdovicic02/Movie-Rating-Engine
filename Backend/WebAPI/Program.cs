using System.Text.Json.Serialization;
using Application.DaoInterfaces;
using Application.Logic;
using Application.LogicInterfaces;
using EfcDataAccess.Context;
using EfcDataAccess.DAOs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddControllers()
    .AddJsonOptions(o => {
        o.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); 
        
        });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IContentLogic, ContentLogic>();

builder.Services.AddScoped<IContentDao, ContentEfcDao>();

builder.Services.AddDbContext<MovieReviewEngineContext>();

var app = builder.Build();

app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true) 
    .AllowCredentials());

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
