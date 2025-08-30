using eCommerce.InfraStructure;
using eCommerce.Core;
using eCommerce.API.Middleware;
using eCommerce.Core.Mapper;
using System.Text.Json.Serialization;
using FluentValidation.AspNetCore;

namespace eCommerce.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddInfrastructure();
            builder.Services.AddCore();
            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });
            builder.Services.AddAutoMapper(typeof(ApplicationUserMappingProfile).Assembly);
            // FluentValidations
            builder.Services.AddFluentValidationAutoValidation();
            var app = builder.Build();
            app.UseExceptionHandlingMiddleware();
            app.UseRouting();
            app.UseAuthorization();
            app.UseAuthentication();
            app.MapControllers();

            app.Run();
        }
    }
}
