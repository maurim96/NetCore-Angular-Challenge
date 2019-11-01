using AutoMapper;
using Domain;
using Persistance.SQL.EFCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistance.SQL.EFCore.AutoMapper
{
    public class EntityToDomainMapper : Profile
    {
        public EntityToDomainMapper()
        {
            CreateMap<Competitions, Competition>();
            CreateMap<Teams, Team>();
            CreateMap<Players, Player>();
            CreateMap<CompetitionsTeams, CompetitionTeam>();
        }
    }
}
