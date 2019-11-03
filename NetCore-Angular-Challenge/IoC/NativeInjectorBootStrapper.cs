using Application.Repositories;
using Application.UoW;
using Application.UseCases.CRUDCompetitions.GetCompetitionsUseCase;
using Application.UseCases.ImportCompetitionUseCase;
using Application.UseCases.PersistCompetitionUseCase;
using ErrorHandler.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Persistance.SQL.EFCore.Repositories;
using Persistance.SQL.EFCore.UoW;

namespace IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {

            services.AddSingleton<IUnitOfWork, UnitOfWork>();

            //Use Cases
            services.AddScoped<IImportCompetitionUseCase, ImportCompetitionUseCase>();
            services.AddScoped<IPersistCompetitionUseCase, PersistCompetitionUseCase>();
            services.AddScoped<IGetCompetitionsUseCase, GetCompetitionsUseCase>();

            //Repositories
            services.AddTransient<ICompetitionRepository, CompetitionRepository>();

            //CrossCuttings
            //ErrorHandler
            services.AddScoped<IErrorHandler, ErrorHandler.Implementations.ErrorHandler>();
        }
    }
}
