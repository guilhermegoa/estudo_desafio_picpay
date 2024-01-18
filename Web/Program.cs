using Challenge.Application;
using Challenge.Infrastructure;
using Challenge.Presentation;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApplication()
    .AddInfrastructure()
    .AddPresentation();

var presentationAssembly = typeof(Challenge.Presentation.DependencyInjection).Assembly;
builder.Services.AddControllers().AddApplicationPart(presentationAssembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

app.MapControllers();

app.Run();
