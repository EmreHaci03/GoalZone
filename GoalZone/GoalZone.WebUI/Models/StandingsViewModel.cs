namespace GoalZone.WebUI.Models
{
    public class StandingsViewModel
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public string TeamLogoUrl { get; set; }
        public int Played { get; set; }
        public int Won { get; set; }
        public int Drawn { get; set; }
        public int Lost { get; set; }
        public int GoalsFor { get; set; }
        public int GoalsAgainst { get; set; }
        public int GoalDiff => GoalsFor - GoalsAgainst;
        public int Points { get; set; }
        public List<string> Form { get; set; } = new();
    }
}
