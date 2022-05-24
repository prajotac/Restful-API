using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Entities.Data;
using Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<UserDatabasesetting>(
                builder.Configuration.GetSection(nameof(UserDatabasesetting)));

builder.Services.AddSingleton<IUserDatabaseSettings>(sp =>
    sp.GetRequiredService<IOptions<UserDatabasesetting>>().Value);

builder.Services.AddSingleton<IMongoClient>(s =>
        new MongoClient(builder.Configuration.GetValue<string>("UserDatabasesetting:ConnectionString")));

builder.Services.AddSingleton<IUserService,UserService>();

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

app.UseAuthorization();

app.MapControllers();

app.Run();
