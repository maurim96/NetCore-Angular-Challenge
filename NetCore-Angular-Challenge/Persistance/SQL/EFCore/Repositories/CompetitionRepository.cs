using Application.Repositories;
using AutoMapper;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistance.SQL.EFCore.Entities;
using System;

namespace Persistance.SQL.EFCore.Repositories
{
    public class CompetitionRepository : ICompetitionRepository
    {
        internal ChallengeDbContext context;
        internal DbSet<Competitions> dbSet;
        private IMapper _mapper;

        public CompetitionRepository(ChallengeDbContext context, IMapper mapper)
        {
            this.context = context;
            this.dbSet = context.Set<Competitions>();
            _mapper = mapper;
        }
        public virtual Competition GetByID(int id)
        {
            return _mapper.Map<Competitions, Competition>(dbSet.Find(id));
        }

        public virtual void Insert(Competition competition)
        {
            Competitions competitionDB = _mapper.Map<Competition, Competitions>(competition);
            dbSet.Add(competitionDB);
        }

        public virtual void Delete(int id)
        {
            Competitions competitionToDelete = dbSet.Find(id);
            Delete(competitionToDelete);
        }

        private void Delete(Competitions competitionToDelete)
        {
            if (context.Entry(competitionToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(competitionToDelete);
            }
            dbSet.Remove(competitionToDelete);
        }

        public virtual void Update(Competition competition)
        {
            Competitions competitionToUpdate = _mapper.Map<Competition, Competitions>(competition);
            dbSet.Attach(competitionToUpdate);
            context.Entry(competitionToUpdate).State = EntityState.Modified;
        }
    }
}
