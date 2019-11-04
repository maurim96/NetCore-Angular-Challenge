using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.UseCases.CRUDCompetitions.GetCompetitionByIdUseCase;
using Application.UseCases.CRUDCompetitions.GetCompetitionsUseCase;
using Application.UseCases.GetNumberOfPlayersByCompetitionUseCase;
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
        private readonly IGetNumberOfPlayersByCompetitionUseCase _getNumberOfPlayersByCompetitionUseCase;
        private readonly IGetCompetitionByIdUseCase _getCompetitionByIdUseCase;
        public CompetitionController(
            IImportCompetitionUseCase importCompetitionUseCase,
            IPersistCompetitionUseCase persistCompetitionUseCase,
            IGetCompetitionsUseCase getCompetitionsUseCase,
            IGetNumberOfPlayersByCompetitionUseCase getNumberOfPlayersByCompetitionUseCase,
            IGetCompetitionByIdUseCase getCompetitionByIdUseCase)
        {
            _importCompetitionUseCase = importCompetitionUseCase;
            _persistCompetitionUseCase = persistCompetitionUseCase;
            _getCompetitionsUseCase = getCompetitionsUseCase;
            _getNumberOfPlayersByCompetitionUseCase = getNumberOfPlayersByCompetitionUseCase;
            _getCompetitionByIdUseCase = getCompetitionByIdUseCase;
        }

        [HttpGet]
        public IActionResult GetCompetitions()
        {
            List<Competition> competitions = _getCompetitionsUseCase.Execute();
            if (competitions.Count > 0)
            {
                return Ok(competitions);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpGet]
        [Route("total-players/{idCompetition}")]
        public IActionResult GetNumberOfPlayersByCompetition(int idCompetition)
        {
            int total = _getNumberOfPlayersByCompetitionUseCase.Execute(idCompetition);

            if (total != -1)
            {
                return Ok(new { total });
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("{idCompetition}")]
        public IActionResult GetCompetitionById(int idCompetition)
        {
            CompleteCompetition reponse = _getCompetitionByIdUseCase.Execute(idCompetition);
            if (Response != null)
            {
                return Ok(reponse);
            }
            else
            {
                return NotFound();
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