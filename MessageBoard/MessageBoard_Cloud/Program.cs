using MessageBoard_Cloud.Data;
using MessageBoard_Cloud.Data.Interfaces;
using MessageBoard_Cloud.Services;
using MessageBoard_Cloud.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerDocument();


//use dependency injection
builder.Services.AddScoped<UserService, MessageBoard_UserService>();
builder.Services.AddScoped<UserData, MessageBoard_UserData>();
builder.Services.AddScoped<MessageData, MessageBoard_MessageData>();
builder.Services.AddScoped<MessageService, MessageBoard_MessageService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi3();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
