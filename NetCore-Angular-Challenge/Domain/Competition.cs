using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Competition
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string AreaName { get; set; }

        public ICollection<CompetitionTeam> TeamsLink { get; set; }
    }
}
