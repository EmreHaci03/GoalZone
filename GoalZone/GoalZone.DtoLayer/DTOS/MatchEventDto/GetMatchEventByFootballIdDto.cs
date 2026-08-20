using GoalZone.EntityLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoalZone.DtoLayer.DTOS.MatchEventDto
{
    public class GetMatchEventByFootballIdDto
    {
        public int MatchEventId { get; set; }
        public int FootballMatchId { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public string FootballMatchName { get; set; }

        public string PlayerName { get; set; }
        public int Minute { get; set; }
        public EventType EventType { get; set; }
    }
}
