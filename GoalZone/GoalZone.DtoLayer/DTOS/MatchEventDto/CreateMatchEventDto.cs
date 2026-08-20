using GoalZone.EntityLayer.Entities;
using GoalZone.EntityLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoalZone.DtoLayer.DTOS.MatchEventDto
{
    public class CreateMatchEventDto
    {
        public int FootballMatchId { get; set; }
        public string PlayerName { get; set; }
        public int Minute { get; set; }
        public EventType EventType { get; set; }
    }
}
