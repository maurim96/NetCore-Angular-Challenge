using Application.UoW;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.PersistCompetitionUseCase
{
    public class PersistCompetitionUseCase : IPersistCompetitionUseCase
    {
        private readonly IUnitOfWork _unitOfWork;
        public PersistCompetitionUseCase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
