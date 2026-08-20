using GoalZone.EntityLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoalZone.DtoLayer.DTOS.DefaultDto
{
    public class MatchStatusCountDto
    {
        public MatchStatus MatchStatus { get; set; }
        public int Count { get; set; }
    }
}
