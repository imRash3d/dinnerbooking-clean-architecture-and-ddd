
using DinnerBooking.Api.Middlewares;
using DinnerBooking.Api.ServiceCollectionExtensions;
using DinnerBooking.Infrastructure;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddTransient<ErrorHandlingMiddleware>();
    builder.Services.AddInfrastructure(); // Call DI
    builder.Services.AddApplication(); // Call DI
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Host.UseSerilog((context, configuration)=>
    configuration.ReadFrom.Configuration(context.Configuration)
    );
}



var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    app.UseMiddleware<ErrorHandlingMiddleware>();
   // app.UseAuthorization();

    app.UseSerilogRequestLogging(); 
    app.MapControllers();

    app.Run();
}



