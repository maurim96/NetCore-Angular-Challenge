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
            CreateMap<ApiResponseCompetition, Competitions>()
                .ForMember(x => x.AreaName, opt => opt.MapFrom(z => z.area.name));
            CreateMap<Team, Teams>();
            CreateMap<TeamAux, Teams>()
                .ForMember(x => x.AreaName, opt => opt.MapFrom(z => z.area.name));
            CreateMap<Player, Players>();
            CreateMap<CompetitionTeam, CompetitionsTeams>();
        }
    }
}
