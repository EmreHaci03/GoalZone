
using GoalZone.EntityLayer.Enums;

namespace GoalZone.DtoLayer.DTOS.FootballMatchDto
{
    public class UpdateFootballMatchDto
    {
        public int FootballMatchId { get; set; }
        public int Week { get; set; }
        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }
        public int? HalfTimeScoreHome { get; set; }
        public int? HalfTimeScoreAway { get; set; }
        public int? FullTimeScoreHome { get; set; }
        public int? FullTimeScoreAway { get; set; }
        public DateTime MatchDate { get; set; }
        public string ImageUrl { get; set; }
        public MatchStatus MatchStatus { get; set; }
    }
}
