using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoalZone.DtoLayer.DTOS.MatchEventDto
{
    public class GetMatchEventByIdDto
    {
        public int MatchEventId { get; set; }
        public int FootballMatchId { get; set; }

        public string PlayerName { get; set; }
        public int Minute { get; set; }
        public string EventType { get; set; }
    }
}
