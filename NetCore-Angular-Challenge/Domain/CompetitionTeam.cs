using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class CompetitionTeam
    {
        public int CompetitionId { get; set; }
        public int TeamId { get; set; }

        public Competition Competition { get; set; }
        public Team Team { get; set; }
    }
}
