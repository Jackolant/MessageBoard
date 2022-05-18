using MessageBoard_Cloud.Data;
using MessageBoard_Cloud.Data.Interfaces;
using MessageBoard_Cloud.Services;
using MessageBoard_Cloud.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

/*NOTE: For this example in order to test and run locally I've disabled cors */
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// Add services to the container.
builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerDocument();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:3000");
                      });
});



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
    app.UseCors(MyAllowSpecificOrigins);
}

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
