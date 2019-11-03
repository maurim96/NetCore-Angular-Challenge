using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.UseCases.CRUDCompetitions.GetCompetitionsUseCase;
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
        private readonly IGetCompetitionsUseCase _getCompetitionsUseCase;
        public CompetitionController(IImportCompetitionUseCase importCompetitionUseCase, IPersistCompetitionUseCase persistCompetitionUseCase, IGetCompetitionsUseCase getCompetitionsUseCase)
        {
            _importCompetitionUseCase = importCompetitionUseCase;
            _persistCompetitionUseCase = persistCompetitionUseCase;
            _getCompetitionsUseCase = getCompetitionsUseCase;
        }

        [HttpGet]
        public IActionResult GetCompetitions()
        {
            List<Competition> competitions = _getCompetitionsUseCase.Execute();
            if (competitions.Count > 0)
            {
                return Ok(competitions.ToList());
            }
            else
            {
                return NoContent();
            }
        }

        [HttpPost]
        [Route("{idCompetition}")]
        public async Task<IActionResult> ImportCompetitionData(int idCompetition)
        {
            ApiCompleteResponse response = await _importCompetitionUseCase.Execute(idCompetition);

            if (response.Status.StatusCode == 201)
            {
                _persistCompetitionUseCase.Execute(response.Data);
            }

            return new ObjectResult(response.Status.Message)
            {
                StatusCode = response.Status.StatusCode
            };
        }
    }
}