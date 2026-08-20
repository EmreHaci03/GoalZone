using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoalZone.EntityLayer.Entities
{
    public class Team
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public string TeamShortName { get; set; }
        public string TeamLogoUrl { get; set; }
        public string TeamManagerName { get; set; }
        public int TeamFoundationYear { get; set; }

        public int StadiumId { get; set; }
        public Stadium Stadium { get; set; }
        public List<Player> Players { get; set; }

        public List<FootballMatch> HomeMatches { get; set; }
        public List<FootballMatch> AwayMatches { get; set; }
        public List<News> News { get; set; }


    }
}
