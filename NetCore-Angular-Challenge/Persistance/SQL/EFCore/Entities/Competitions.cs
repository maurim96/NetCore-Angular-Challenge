using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Persistance.SQL.EFCore.Entities
{
    public partial class Competitions
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string AreaName { get; set; }

        public ICollection<CompetitionTeam> TeamsLink { get; set; }
    }
}
