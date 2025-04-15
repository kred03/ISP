using Lab5.Application.Interfaces;
using Lab5.Application.Services;
using Lab5.Application.SuperPowerMappingProfile;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Lab5.Application
{
    public static class ServiceCollectionExtension
    {
        public static void AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(MappingProfile)); 
            
            services.AddScoped<ISuperHeroService, SuperHeroService>(); 
            services.AddScoped<ISuperPowerService, SuperPowerService>(); 
        }
    }
}