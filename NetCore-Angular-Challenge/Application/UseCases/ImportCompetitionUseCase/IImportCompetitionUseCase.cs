using Domain;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.ImportCompetitionUseCase
{
    public interface IImportCompetitionUseCase
    {
        Task<ApiCompleteResponse> Execute(int idCompetition);
    }
}
