using Application.Repositories;
using AutoMapper;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistance.SQL.EFCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistance.SQL.EFCore.Repositories
{
    public class CompetitionTeamRepository : ICompetitionTeamRepository
    {
        internal ChallengeDbContext _context;
        private IMapper _mapper;

        public CompetitionTeamRepository(ChallengeDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public virtual CompetitionTeam GetByID(int id)
        {
            return _mapper.Map<CompetitionsTeams, CompetitionTeam>(_context.CompetitionsTeams.Find(id));
        }

        public virtual void Insert(CompetitionTeam compTeam)
        {
            CompetitionsTeams compTeamDB = _mapper.Map<CompetitionTeam, CompetitionsTeams>(compTeam);
            _context.CompetitionsTeams.Add(compTeamDB);
        }

        public virtual void Delete(int id)
        {
            CompetitionsTeams compTeamToDelete = _context.CompetitionsTeams.Find(id);
            Delete(compTeamToDelete);
        }

        private void Delete(CompetitionsTeams compTeamToDelete)
        {
            if (_context.Entry(compTeamToDelete).State == EntityState.Detached)
            {
                _context.CompetitionsTeams.Attach(compTeamToDelete);
            }
            _context.CompetitionsTeams.Remove(compTeamToDelete);
        }

        public virtual void Update(CompetitionTeam compTeam)
        {
            CompetitionsTeams compTeamToUpdate = _mapper.Map<CompetitionTeam, CompetitionsTeams>(compTeam);
            _context.CompetitionsTeams.Attach(compTeamToUpdate);
            _context.Entry(compTeamToUpdate).State = EntityState.Modified;
        }
    }
}
