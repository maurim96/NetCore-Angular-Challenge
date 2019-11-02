using Application.Repositories;
using AutoMapper;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistance.SQL.EFCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persistance.SQL.EFCore.Repositories
{
    public class CompetitionRepository : ICompetitionRepository
    {
        internal ChallengeDbContext _context;
        private IMapper _mapper;

        public CompetitionRepository(ChallengeDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public virtual List<Competition> GetCompetitions()
        {
            return _mapper.Map<List<Competitions>, List<Competition>>(_context.Competitions.ToList());
        }
        public virtual Competition GetByID(int id)
        {
            return _mapper.Map<Competitions, Competition>(_context.Competitions.Find(id));
        }

        public virtual void Insert(Competition competition)
        {
            Competitions competitionDB = _mapper.Map<Competition, Competitions>(competition);
            _context.Competitions.Add(competitionDB);
        }

        public virtual void Insert(ApiResponseCompetition competition)
        {
            Competitions competitionDB = _mapper.Map<ApiResponseCompetition, Competitions>(competition);
            _context.Competitions.Add(competitionDB);
        }

        public virtual void Delete(int id)
        {
            Competitions competitionToDelete = _context.Competitions.Find(id);
            Delete(competitionToDelete);
        }

        private void Delete(Competitions competitionToDelete)
        {
            if (_context.Entry(competitionToDelete).State == EntityState.Detached)
            {
                _context.Competitions.Attach(competitionToDelete);
            }
            _context.Competitions.Remove(competitionToDelete);
        }

        public virtual void Update(Competition competition)
        {
            Competitions competitionToUpdate = _mapper.Map<Competition, Competitions>(competition);
            _context.Competitions.Attach(competitionToUpdate);
            _context.Entry(competitionToUpdate).State = EntityState.Modified;
        }
    }
}
