using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Repositories
{
    public interface ITeamRepository
    {
        Team GetByID(int id);

        void Insert(Team team);
        void Insert(TeamAux team);

        void Delete(int id);

        void Update(Team team);
    }
}
