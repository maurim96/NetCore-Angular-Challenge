using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Repositories
{
    public interface ICompetitionTeamRepository
    {
        CompetitionTeam GetByID(int id);

        void Insert(CompetitionTeam competitionTeam);

        void Delete(int id);

        void Update(CompetitionTeam competitionTeam);
    }
}
