using Application.UoW;
using Domain;
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
        public void Execute(CompetitionData data)
        {
            _unitOfWork.CompetitionRepository.Insert(data.Competition);

            foreach (TeamAux team in data.Teams)
            {

                if (_unitOfWork.TeamRepository.GetByID(team.Id) == null)
                {
                    _unitOfWork.TeamRepository.Insert(team);
                }
                GenerateTeamCompetition(data.Competition.id, team.Id);
            }

            _unitOfWork.Commit();
        }

        private void GenerateTeamCompetition(int idCompetition, int idTeam)
        {
            CompetitionTeam compTeam = new CompetitionTeam
            {
                CompetitionId = idCompetition,
                TeamId = idTeam
            };
            _unitOfWork.CompetitionTeamRepository.Insert(compTeam);
        }
    }
}
