using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.UseCases.ImportCompetitionUseCase;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        private IImportCompetitionUseCase _importCompetitionUseCase;
        public SampleDataController(IImportCompetitionUseCase importCompetitionUseCase)
        {
            _importCompetitionUseCase = importCompetitionUseCase;
        }

        [HttpGet("")]
        public void Get()
        {
            _importCompetitionUseCase.GetCompetitions();
        }
    }
}
