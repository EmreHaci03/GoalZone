using GoalZone.EntityLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoalZone.EntityLayer.Entities
{
    public class FootballMatch //Fixture
    {
        public int FootballMatchId { get; set; }
        public int Week { get; set; }

        public int HomeTeamId { get; set; }
        public Team HomeTeam { get; set; }
        public int AwayTeamId { get; set; }
        public Team AwayTeam { get; set; }

        public int? HalfTimeScoreHome { get; set; }  
        public int? HalfTimeScoreAway { get; set; }
        public int? FullTimeScoreHome { get; set; }
        public int? FullTimeScoreAway { get; set; }

        public DateTime MatchDate  { get; set; }
        public string ImageUrl { get; set; }

        public MatchStatus MatchStatus { get; set; }

        public List<MatchEvent> MatchEvents { get; set; }
        public List<MatchStatistic> MatchStatistics { get; set; }


    }
}
