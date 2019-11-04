using System.Collections.Generic;
using System.Linq;
using Application.UoW;
using Domain;

namespace Application.UseCases.CRUDCompetitions.GetCompetitionByIdUseCase
{
    public class GetCompetitionByIdUseCase : IGetCompetitionByIdUseCase
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetCompetitionByIdUseCase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public CompleteCompetition Execute(int idCompetition)
        {
            List<Team> teams = new List<Team>();
            List<CompetitionTeam> compTeamList = _unitOfWork.CompetitionTeamRepository.GetByCompetitionIdWithoutPlayers(idCompetition);
            Competition competition = _unitOfWork.CompetitionRepository.GetByID(idCompetition);
            competition.TeamsLink = null;

            foreach (CompetitionTeam compTeam in compTeamList)
            {
                //compTeam.Team.Players = null;
                compTeam.Team.CompetitionsLink = null;
                teams.Add(compTeam.Team);
            }
            return new CompleteCompetition
            {
                competition = competition,
                teams = teams
            };
        }
    }
}
