using System;
using Xunit;
using Moq;
using Persistance.SQL.EFCore.Entities;
using Microsoft.EntityFrameworkCore;
using Persistance.SQL.EFCore.Repositories;
using Domain;
using AutoMapper;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Persistance.SQL.EFCore.AutoMapper;

namespace Test.Persistance
{
    public class CompetitionRepositoryTest
    {
        private ChallengeDbContext _context;
        private IMapper _mapper;
        public CompetitionRepositoryTest()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new EntityToDomainMapper());
            });
            _mapper = config.CreateMapper();
            var optionsBuilder = new DbContextOptionsBuilder<ChallengeDbContext>()
                    .UseInMemoryDatabase(databaseName: "CompetitionRepositoryTest")
                    .Options;
            _context = new ChallengeDbContext(optionsBuilder);

            if (_context.Competitions.ToList().Count == 0)
            {
                _context.Competitions.AddRange(GetFakeListOfCompetitions());
                _context.SaveChanges();
            }
        }
        [Fact]
        public void GetCompetitionsAndReturnExactQuantity()
        {
            CompetitionRepository competitionRepository = new CompetitionRepository(_context, _mapper);

            //Act
            var items = competitionRepository.GetCompetitions();

            //Assert
            Assert.Equal(2, items.Count);
        }

        [Fact]
        public void GetCompetitionByIdAndReturnCompetition()
        {
            CompetitionRepository competitionRepository = new CompetitionRepository(_context, _mapper);

            //Act
            var items = competitionRepository.GetByID(1);

            //Assert
            Assert.Equal("Superliga Argentina", items.Name);
        }

        private IEnumerable<Competitions> GetFakeListOfCompetitions()
        {
            var competitions = new List<Competitions>
        {
            new Competitions {Id = 1, Name = "Superliga Argentina", Code = "SAF", AreaName = "Argentina"},
            new Competitions {Id = 2, Name = "Liga de Brasil", Code = "LB", AreaName = "Brasil"}
        };

            return competitions;
        }
    }
}
