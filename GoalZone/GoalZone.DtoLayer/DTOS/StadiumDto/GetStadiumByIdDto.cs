using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoalZone.DtoLayer.DTOS.StadiumDto
{
    public class GetStadiumByIdDto
    {
        public int StadiumId { get; set; }
        public string StadiumName { get; set; }
        public string City { get; set; }
        public int Capacity { get; set; }
    }
}
