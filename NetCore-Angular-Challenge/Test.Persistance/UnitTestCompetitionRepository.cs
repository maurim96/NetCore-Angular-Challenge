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
    public class UnitTestCompetitionRepository
    {
        [Fact]
        public void GetCompetitionsAndReturnExactQuantity()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ChallengeDbContext>()
                    .UseInMemoryDatabase(databaseName: "UnitTestCompetitionRepository")
                    .Options;
            ChallengeDbContext mockDbContext = new ChallengeDbContext(optionsBuilder);
            mockDbContext.Competitions.AddRange(GetFakeListOfCompetitions());
            mockDbContext.SaveChanges();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new EntityToDomainMapper());
            });
            var mapper = config.CreateMapper();
            CompetitionRepository competitionRepository = new CompetitionRepository(mockDbContext, mapper);

            //Act
            var items = competitionRepository.GetCompetitions();

            //Assert
            Assert.Equal(2, items.Count);
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
