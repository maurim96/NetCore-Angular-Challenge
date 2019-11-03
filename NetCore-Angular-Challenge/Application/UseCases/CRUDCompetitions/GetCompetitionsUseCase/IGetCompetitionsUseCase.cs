using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.CRUDCompetitions.GetCompetitionsUseCase
{
    public interface IGetCompetitionsUseCase
    {
        List<Competition> Execute();
    }
}
