using System;
using System.Collections.Generic;
using System.Text;

namespace Persistance.SQL.EFCore.Entities
{
    public partial class CompetitionTeam
    {
        public int CompetitionId { get; set; }
        public int TeamId { get; set; }

        public Competitions Competition { get; set; }
        public Teams Team { get; set; }
    }
}
