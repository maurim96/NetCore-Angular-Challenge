using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.UseCases.ImportCompetitionUseCase;
using Application.UseCases.PersistCompetitionUseCase;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.Filters;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(WebApiExceptionFilterAttribute))]
    public class CompetitionController : ControllerBase
    {
        private readonly IImportCompetitionUseCase _importCompetitionUseCase;
        private readonly IPersistCompetitionUseCase _persistCompetitionUseCase;
        public CompetitionController(IImportCompetitionUseCase importCompetitionUseCase, IPersistCompetitionUseCase persistCompetitionUseCase)
        {
            _importCompetitionUseCase = importCompetitionUseCase;
            _persistCompetitionUseCase = persistCompetitionUseCase;
        }

        [HttpPost]
        [Route("{idCompetition}")]
        public async Task ImportCompetitionData(int idCompetition)
        {
            ApiCompleteResponse result = await _importCompetitionUseCase.Execute(idCompetition);
        }
    }
}