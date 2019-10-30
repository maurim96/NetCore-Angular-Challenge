using Application.Repositories;
using Application.UoW;
using Application.UseCases.ImportCompetitionUseCase;
using ErrorHandler.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Persistance.SQL.EFCore.Entities;
using Persistance.SQL.EFCore.Repositories;
using Persistance.SQL.EFCore.UoW;
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
            services.AddSingleton<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IImportCompetitionUseCase, ImportCompetitionUseCase>();

            //Repositories
            //services.AddTransient<IGenericRepository<TEntity>, GenericRepository<TEntity>>();
            services.AddTransient<ICompetitionRepository, CompetitionRepository>();

            //CrossCuttings
            //ErrorHandler
            services.AddScoped<IErrorHandler, ErrorHandler.Implementations.ErrorHandler>();
        }
    }
}
