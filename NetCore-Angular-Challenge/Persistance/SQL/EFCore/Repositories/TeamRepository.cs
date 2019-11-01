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
    public class TeamRepository : ITeamRepository
    {
        internal ChallengeDbContext _context;
        private IMapper _mapper;

        public TeamRepository(ChallengeDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public virtual Team GetByID(int id)
        {
            return _mapper.Map<Teams, Team>(_context.Teams.Find(id));
        }

        public virtual void Insert(Team team)
        {
            Teams teamDB = _mapper.Map<Team, Teams>(team);
            _context.Teams.Add(teamDB);
        }

        public virtual void Insert(TeamAux team)
        {
            Teams teamDB = _mapper.Map<TeamAux, Teams>(team);
            _context.Teams.Add(teamDB);
        }

        public virtual void Delete(int id)
        {
            Teams teamToDelete = _context.Teams.Find(id);
            Delete(teamToDelete);
        }

        private void Delete(Teams teamToDelete)
        {
            if (_context.Entry(teamToDelete).State == EntityState.Detached)
            {
                _context.Teams.Attach(teamToDelete);
            }
            _context.Teams.Remove(teamToDelete);
        }

        public virtual void Update(Team team)
        {
            Teams competitionToUpdate = _mapper.Map<Team, Teams>(team);
            _context.Teams.Attach(competitionToUpdate);
            _context.Entry(competitionToUpdate).State = EntityState.Modified;
        }
    }
}
