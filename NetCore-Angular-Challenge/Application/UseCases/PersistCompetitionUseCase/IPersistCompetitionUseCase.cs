using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.PersistCompetitionUseCase
{
    public interface IPersistCompetitionUseCase
    {
        void Execute(CompetitionData data);
    }
}
