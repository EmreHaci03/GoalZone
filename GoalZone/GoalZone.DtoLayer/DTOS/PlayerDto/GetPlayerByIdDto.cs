using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoalZone.DtoLayer.DTOS.PlayerDto
{
    public class GetPlayerByIdDto
    {
        public int PlayerId { get; set; }
        public string PlayerName { get; set; }
        public string Position { get; set; }
        public int JerseyNumber { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Nationality { get; set; }
        public string TeamName { get; set; }
    }
}
