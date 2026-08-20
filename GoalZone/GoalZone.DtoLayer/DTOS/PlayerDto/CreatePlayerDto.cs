using GoalZone.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoalZone.DtoLayer.DTOS.PlayerDto
{
    public class CreatePlayerDto
    {
        public string PlayerName { get; set; }
        public string Position { get; set; }     
        public int JerseyNumber { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Nationality { get; set; }

        public int TeamId { get; set; }
    }
}
