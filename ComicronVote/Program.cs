using AutoMapper;
using ComicronVote.Context;
using ComicronVote.Context.Configurations;
using ComicronVote.DTOs;
using ComicronVote.Mappings;
using ComicronVote.Models;
using ComicronVote.Repository;
using ComicronVote.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowOrigin",
        builder =>
        {
            builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
        });
});

builder.Services.AddDbContext<ComicronDB>();
builder.Services.AddScoped<IFilmRepository, FilmRepository>();
builder.Services.AddScoped<IFilmService, FilmService>();

builder.Services.AddScoped<IVotoRepository, VotoRepository>();
builder.Services.AddScoped<IVotoService, VotoService>();

//aggiunta dei mapper (entity -> dto, viceversa)
var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new VotoMapper());
    
});

var mapper = mappingConfig.CreateMapper();

builder.Services.AddSingleton(mapper);

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors(builder => builder
.AllowAnyHeader()
.AllowAnyMethod()
.SetIsOriginAllowed((host) => true)
.AllowCredentials());

app.UseHttpsRedirection();
app.MapControllers();
app.Run();