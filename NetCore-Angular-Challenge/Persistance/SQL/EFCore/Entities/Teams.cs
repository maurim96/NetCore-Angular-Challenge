using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Persistance.SQL.EFCore.Entities
{
    public partial class Teams
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Tla { get; set; }
        public string ShortName { get; set; }
        public string AreaName { get; set; }
        public string Email { get; set; }
        public ICollection<Players> Players { get; set; }
        public ICollection<CompetitionsTeams> CompetitionsLink { get; set; }

    }
}
