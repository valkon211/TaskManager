using System.Reflection;
using FluentValidation;
using MediatR;
using TaskManager.Application.Common.Behaviors;
using TaskManager.Application.Extensions;
using TaskManager.Application.Validators;
using TaskManager.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add Infrastructure и Application layer
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();

// MediatR & FluentValidation
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
builder.Services.AddValidatorsFromAssemblyContaining<CreateTaskCommandValidator>();

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