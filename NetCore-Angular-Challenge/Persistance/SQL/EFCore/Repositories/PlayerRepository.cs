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
    public class PlayerRepository : IPlayerRepository
    {
        internal ChallengeDbContext _context;
        private IMapper _mapper;

        public PlayerRepository(ChallengeDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public virtual Player GetByID(int id)
        {
            return _mapper.Map<Players, Player>(_context.Players.Find(id));
        }

        public virtual void Insert(Player player)
        {
            Players playerDB = _mapper.Map<Player, Players>(player);
            _context.Players.Add(playerDB);
        }

        public virtual void Delete(int id)
        {
            Players playerToDelete = _context.Players.Find(id);
            Delete(playerToDelete);
        }

        private void Delete(Players playerToDelete)
        {
            if (_context.Entry(playerToDelete).State == EntityState.Detached)
            {
                _context.Players.Attach(playerToDelete);
            }
            _context.Players.Remove(playerToDelete);
        }

        public virtual void Update(Player player)
        {
            Players playerToUpdate = _mapper.Map<Player, Players>(player);
            _context.Players.Attach(playerToUpdate);
            _context.Entry(playerToUpdate).State = EntityState.Modified;
        }
    }
}
