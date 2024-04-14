using Infrastructure.Data;
using Infrastructure.Interfaces;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddScoped<IGroupService,GroupService>();
builder.Services.AddScoped<ILocationService,LocationService>();
builder.Services.AddScoped<IParticipantService,ParticipantService>();
builder.Services.AddScoped<IChallengeService,ChallengeService>();


var Connection = builder.Configuration.GetConnectionString("Connection");
builder.Services.AddDbContext<DataContext>(e => e.UseNpgsql(Connection));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapControllers();


app.Run();






