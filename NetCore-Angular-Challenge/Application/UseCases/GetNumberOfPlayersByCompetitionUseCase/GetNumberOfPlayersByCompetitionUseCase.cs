using Application.UoW;
using Domain;
using System.Collections.Generic;

namespace Application.UseCases.GetNumberOfPlayersByCompetitionUseCase
{
    public class GetNumberOfPlayersByCompetitionUseCase : IGetNumberOfPlayersByCompetitionUseCase
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetNumberOfPlayersByCompetitionUseCase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public int Execute(int idCompetition)
        {
            int numberOfPlayers = 0;
            List<CompetitionTeam> compTeamList = _unitOfWork.CompetitionTeamRepository.GetByCompetitionId(idCompetition);

            if (compTeamList != null)
            {
                foreach (CompetitionTeam compTeam in compTeamList)
                {
                    numberOfPlayers += compTeam.Team.Players.Count;
                }
            }
            else
            {
                numberOfPlayers = -1;
            }
            return numberOfPlayers;
        }
    }
}
