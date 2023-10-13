using Timelogger.WebApi.Middleware;
using Timelogger.Application;
using Timelogger.Data;
using Timelogger.WebApi.Identity;
using System.Collections.Specialized;
using System.Text.Json.Serialization;

namespace Timelogger.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers().AddJsonOptions(opt => opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddApplicationServices();
            builder.Services.AddDataContext();
            builder.Services.AddIdentityProvider();     

            var app = builder.Build();
            using IServiceScope serviceScope = app.Services.CreateScope();
            serviceScope.ServiceProvider.GetRequiredService<TimeloggerDbContext>().Database.EnsureCreated();  

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            app.UseExceptionHandler(new ExceptionHandlerOptions()
            {
                ExceptionHandler = new ExceptionHandlingMiddleware().InvokeAsync
            });

            app.MapControllers();

            app.Run();
        }
    }
}