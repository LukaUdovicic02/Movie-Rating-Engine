using System.Text.Json.Serialization;
using Application.DaoInterfaces;
using Application.Logic;
using Application.LogicInterfaces;
using Domain.DTOs.ContentDtos;
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
builder.Services.AddScoped<IReviewLogic, ReviewLogic>();

builder.Services.AddScoped<IContentDao, ContentEfcDao>();
builder.Services.AddScoped<IReviewDao, ReviewDao>();

builder.Services.AddDbContext<MovieReviewEngineContext>();

var app = builder.Build();



app.Use(async (context, next) =>
{
    if (context.Request.Path.StartsWithSegments("/api/review") && context.Request.Method == "POST")
    {
         // ovo bi islo obicno u appsettings/.env file radi sigurnosti ali sad samo uradio ovako
         
        if (!context.Request.Headers.TryGetValue("Key", out var extractedKey))
        {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("API Key is missing.");
            return;
        }

        if (extractedKey != "Key")
        {
            context.Response.StatusCode = 403;
            await context.Response.WriteAsync("Unauthorized: Invalid API Key.");
            return;
        }
    }

    await next();
});

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
