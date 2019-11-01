using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Repositories
{
    public interface IPlayerRepository
    {
        Player GetByID(int id);

        void Insert(Player player);

        void Delete(int id);

        void Update(Player player);
    }
}
