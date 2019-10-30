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
        private IMapper _mapper;

        public UnitOfWork(IMapper mapper)
        {
            _mapper = mapper;
        }

        //private IGenericRepository<Competitions> _competitionsRepository;
        //private IGenericRepository<Teams> _teamsRepository;
        //private IGenericRepository<Players> _playersRepository;
        //private IGenericRepository<CompetitionTeam> _compTeamRepository;
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

        //public IGenericRepository<Competitions> CompetitionsRepository
        //{
        //    get
        //    {

        //        if (_competitionsRepository == null)
        //        {
        //            _competitionsRepository = _competitionsRepository ?? new GenericRepository<Competitions>(_context);
        //        }
        //        return _competitionsRepository;
        //    }
        //}

        //public IGenericRepository<Teams> TeamsRepository
        //{
        //    get
        //    {

        //        if (_teamsRepository == null)
        //        {
        //            _teamsRepository = _teamsRepository ?? new GenericRepository<Teams>(_context);
        //        }
        //        return _teamsRepository;
        //    }
        //}

        //public IGenericRepository<Players> PlayersRepository
        //{
        //    get
        //    {

        //        if (_playersRepository == null)
        //        {
        //            _playersRepository = _playersRepository ?? new GenericRepository<Players>(_context);
        //        }
        //        return _playersRepository;
        //    }
        //}

        //public IGenericRepository<CompetitionTeam> CompTeamRepository
        //{
        //    get
        //    {

        //        if (_compTeamRepository == null)
        //        {
        //            _compTeamRepository = _compTeamRepository ?? new GenericRepository<CompetitionTeam>(_context);
        //        }
        //        return _compTeamRepository;
        //    }
        //}

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
