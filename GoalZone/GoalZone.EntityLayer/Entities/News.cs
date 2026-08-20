using GoalZone.EntityLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoalZone.EntityLayer.Entities
{
    public class News
    {
        public int NewsId { get; set; }
        public string Title { get; set; }            
        public string ShortDescription { get; set; }   
        public string Content { get; set; }        
        public string ImageUrl { get; set; }         
        public string Source { get; set; }           
        public string SourceUrl { get; set; }      
        public DateTime PublishDate { get; set; }     
        public int ViewCount { get; set; }           
        public bool IsFeatured { get; set; }           
        public NewsCategory Category { get; set; }     
        public string Tags { get; set; }               
        public int? RelatedTeamId { get; set; }
        public Team RelatedTeam { get; set; }

    }
}
