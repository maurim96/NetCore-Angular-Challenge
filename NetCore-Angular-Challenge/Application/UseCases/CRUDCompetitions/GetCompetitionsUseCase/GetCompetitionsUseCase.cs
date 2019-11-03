using System;
using System.Collections.Generic;
using System.Text;
using Application.Repositories;
using Domain;

namespace Application.UseCases.CRUDCompetitions.GetCompetitionsUseCase
{
    public class GetCompetitionsUseCase : IGetCompetitionsUseCase
    {
        private readonly ICompetitionRepository _competitionRepository;
        public GetCompetitionsUseCase(ICompetitionRepository competitionRepository)
        {
            _competitionRepository = competitionRepository;
        }
        public List<Competition> Execute()
        {
            try
            {
                return _competitionRepository.GetCompetitions();
            }
            catch (Exception)
            {
                throw new Exception("Server error");
            }
        }
    }
}
