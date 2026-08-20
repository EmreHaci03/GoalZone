using GoalZone.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoalZone.DtoLayer.DTOS.TeamDto
{
    public class UpdateTeamDto
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public string TeamShortName { get; set; }
        public string TeamLogoUrl { get; set; }
        public string TeamManagerName { get; set; }
        public int TeamFoundationYear { get; set; }
        public int StadiumId { get; set; }
    }
}
