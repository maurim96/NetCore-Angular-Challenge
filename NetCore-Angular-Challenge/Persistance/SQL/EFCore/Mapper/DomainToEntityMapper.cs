using AutoMapper;
using Domain;
using Persistance.SQL.EFCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistance.SQL.EFCore.AutoMapper
{
    public class DomainToEntityMapper : Profile
    {
        public DomainToEntityMapper()
        {
            CreateMap<Competition, Competitions>();
            CreateMap<Team, Teams>();
            CreateMap<Player, Players>();
            CreateMap<Domain.CompetitionTeam, Entities.CompetitionTeam>();
        }
    }
}
