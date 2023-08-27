
namespace DinoApi.Extensions;

public static class ApplicationServiceExtension
{
    public static void ConfigureCors(this IServiceCollection services) => services.AddCors(options => {
        options.AddPolicy("CorsPolicy", builder =>
            builder.AllowAnyHeader()
            .AllowAnyMethod()
            .AllowAnyHeader()
            );
    });
}
