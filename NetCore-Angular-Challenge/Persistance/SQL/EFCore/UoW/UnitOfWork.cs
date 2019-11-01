using Application.Repositories;
using Application.UoW;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Persistance.SQL.EFCore.Entities;
using Persistance.SQL.EFCore.Repositories;
using System;
using System.Linq;

namespace Persistance.SQL.EFCore.UoW
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private ChallengeDbContext _context = new ChallengeDbContext();
        private ICompetitionRepository _competitionRepository;
        private ITeamRepository _teamRepository;
        private IPlayerRepository _playerRepository;
        private ICompetitionTeamRepository _competitionTeamRepository;
        private IMapper _mapper;

        public UnitOfWork(IMapper mapper)
        {
            _mapper = mapper;
        }

        private bool disposed = false;

        public ICompetitionRepository CompetitionRepository
        {
            get
            {
                if(_competitionRepository == null)
                {
                    _competitionRepository = new CompetitionRepository(_context, _mapper);
                }
                return _competitionRepository;
            }
        }

        public ITeamRepository TeamRepository
        {
            get
            {
                if (_teamRepository == null)
                {
                    _teamRepository = new TeamRepository(_context, _mapper);
                }
                return _teamRepository;
            }
        }

        public IPlayerRepository PlayerRepository
        {
            get
            {
                if (_playerRepository== null)
                {
                    _playerRepository = new PlayerRepository(_context, _mapper);
                }
                return _playerRepository;
            }
        }

        public ICompetitionTeamRepository CompetitionTeamRepository
        {
            get
            {
                if (_competitionTeamRepository == null)
                {
                    _competitionTeamRepository = new CompetitionTeamRepository(_context, _mapper);
                }
                return _competitionTeamRepository;
            }
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void RejectChanges()
        {
            foreach (var entry in _context.ChangeTracker.Entries()
                  .Where(e => e.State != EntityState.Unchanged))
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Modified:
                    case EntityState.Deleted:
                        entry.Reload();
                        break;
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
    }
}
