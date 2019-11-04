using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.CRUDCompetitions.GetCompetitionByIdUseCase
{
    public interface IGetCompetitionByIdUseCase
    {
        CompleteCompetition Execute(int idCompetition);
    }
}
