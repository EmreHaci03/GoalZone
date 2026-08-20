using GoalZone.EntityLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoalZone.EntityLayer.Entities
{
    public class MatchEvent
    {
        public int MatchEventId { get; set; }

        public int FootballMatchId { get; set; }
        public FootballMatch FootballMatch { get; set; }

        public string PlayerName { get; set; }   
        public int Minute { get; set; }
        public EventType EventType { get; set; }
    }
}
