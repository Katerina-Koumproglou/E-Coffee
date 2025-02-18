using BackEnd.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/capsules", async (ApplicationDbContext dbContext) =>
{
    var capsules = await dbContext.Capsules.ToListAsync();
    return Results.Ok(capsules);
});

app.MapGet("/machines", async (ApplicationDbContext dbContext) =>
{
    var machines = await dbContext.Machines.ToListAsync();
    return Results.Ok(machines);
});

app.Run();