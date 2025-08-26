using TaskManager.Application.Extensions;
using TaskManager.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add Infrastructure и Application layer
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();

// Add controllers
builder.Services.AddControllers();

// Add Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();