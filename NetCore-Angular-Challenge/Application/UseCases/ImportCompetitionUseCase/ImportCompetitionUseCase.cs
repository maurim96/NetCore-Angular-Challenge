using Application.UoW;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.ImportCompetitionUseCase
{
    public class ImportCompetitionUseCase : IImportCompetitionUseCase
    {
        private IUnitOfWork _unitOfWork;
        public ImportCompetitionUseCase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void GetCompetitions()
        {
            _unitOfWork.CompetitionRepository.GetByID(12);
        }
    }
}
