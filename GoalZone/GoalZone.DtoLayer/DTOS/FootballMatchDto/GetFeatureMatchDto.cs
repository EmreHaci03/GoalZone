using GoalZone.EntityLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoalZone.DtoLayer.DTOS.FootballMatchDto
{
    public class GetFeatureMatchDto
    {
        public int FootballMatchId { get; set; }
        public int Week { get; set; }
        public string HomeTeamName { get; set; }
        public string HomeTeamLogoUrl { get; set; }
        public string AwayTeamName { get; set; }
        public string AwayTeamLogoUrl { get; set; }
        public int? HalfTimeScoreHome { get; set; }
        public int? HalfTimeScoreAway { get; set; }
        public int? FullTimeScoreHome { get; set; }
        public int? FullTimeScoreAway { get; set; }
        public DateTime MatchDate { get; set; }
        public string StadiumName { get; set; }
        public string ImageUrl { get; set; }
        public MatchStatus MatchStatus { get; set; }
    }
}
