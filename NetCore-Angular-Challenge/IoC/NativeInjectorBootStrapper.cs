using ErrorHandler.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Use Cases
            //services.AddScoped<IGetAllWeatherForecastUseCase, GetAllWeatherForecastUseCase>();

            //Repositories
            //services.AddTransient<IWeatherForecastRepository, WeatherForecastRepository>();

            //CrossCuttings
            //ErrorHandler
            services.AddScoped<IErrorHandler, ErrorHandler.Implementations.ErrorHandler>();
        }
    }
}
