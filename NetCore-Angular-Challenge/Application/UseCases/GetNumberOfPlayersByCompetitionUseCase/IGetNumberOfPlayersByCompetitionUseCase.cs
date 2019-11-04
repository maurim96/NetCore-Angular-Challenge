using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.GetNumberOfPlayersByCompetitionUseCase
{
    public interface IGetNumberOfPlayersByCompetitionUseCase
    {
        int Execute(int idCompetition);
    }
}
