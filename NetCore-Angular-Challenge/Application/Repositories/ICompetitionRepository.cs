using Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface ICompetitionRepository
    {
        Competition GetByID(int id);
        List<Competition> GetCompetitions();
        void Insert(Competition competition);
        void Insert(ApiResponseCompetition competition);
        void Delete(int id);
        void Update(Competition competition);
    }
}
