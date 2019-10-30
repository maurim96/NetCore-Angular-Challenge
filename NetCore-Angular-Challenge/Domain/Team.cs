using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Tla { get; set; }
        public string ShortName { get; set; }
        public string AreaName { get; set; }
        public string Email { get; set; }
        public ICollection<Player> Players { get; set; }
        public ICollection<CompetitionTeam> CompetitionsLink { get; set; }

    }
}
