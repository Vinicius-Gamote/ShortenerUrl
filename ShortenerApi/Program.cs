using Microsoft.EntityFrameworkCore;
using ShortenerApi.Application.Interfaces;
using ShortenerApi.Application.Services;
using ShortenerApi.Domain.Interfaces;
using ShortenerApi.Infrastructure.Data;
using ShortenerApi.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddLogging();
builder.Services.AddTransient<IShortenerService, ShortenerService>();
builder.Services.AddTransient<IShortUrlRepository, ShortUrlRepository>();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

app.Use(async (context, next) =>
    {
        if (context.Request.Path == "/")
        {
            context.Response.Redirect("/swagger");
            return;
        }
        await next();
    });

app.MapOpenApi();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.MapControllers();
app.Run();

