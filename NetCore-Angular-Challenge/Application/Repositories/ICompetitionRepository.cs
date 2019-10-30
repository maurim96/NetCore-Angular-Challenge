using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Repositories
{
    public interface ICompetitionRepository
    {
        Competition GetByID(int id);

        void Insert(Competition competition);

        void Delete(int id);

        void Update(Competition competition);
    }
}
