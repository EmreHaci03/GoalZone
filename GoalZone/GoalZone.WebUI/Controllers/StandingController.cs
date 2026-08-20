using GoalZone.DtoLayer.DTOS.FootballMatchDto;
using GoalZone.DtoLayer.DTOS.TeamDto;
using GoalZone.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GoalZone.WebUI.Controllers
{
    public class StandingController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;

        public StandingController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = httpClientFactory.CreateClient();

            var matchResponse = await client.GetAsync("https://localhost:7084/api/FootballMatch");
            var teamResponse = await client.GetAsync("https://localhost:7084/api/Teams");

            var allMatches = new List<ResultFootballMatchDto>();
            var allTeams = new List<ResultTeamDto>();

            if (matchResponse.IsSuccessStatusCode)
            {
                var json = await matchResponse.Content.ReadAsStringAsync();
                allMatches = JsonConvert.DeserializeObject<List<ResultFootballMatchDto>>(json) ?? new();
            }
            if (teamResponse.IsSuccessStatusCode)
            {
                var json = await teamResponse.Content.ReadAsStringAsync();
                allTeams = JsonConvert.DeserializeObject<List<ResultTeamDto>>(json) ?? new();
            }



            var finished = allMatches.Where(x => x.MatchStatus == "Finished").ToList();

            var weekMatch = finished
                .Where(x => x.FullTimeScoreHome.HasValue && x.FullTimeScoreAway.HasValue)
                .OrderByDescending(x => x.FullTimeScoreHome + x.FullTimeScoreAway)
                .ThenByDescending(x => x.MatchDate)
                .FirstOrDefault();

            ViewBag.WeekMatch = weekMatch;
            var standings = new List<StandingsViewModel>();

            foreach (var team in allTeams)
            {
                //  takımın tüm maçları (ev + deplasman), tarihe göre sıralı
                var teamMatches = finished
                    .Where(m => m.HomeTeamName == team.TeamName || m.AwayTeamName == team.TeamName)
                    .OrderBy(m => m.MatchDate)
                    .ToList();

                int played = 0, won = 0, drawn = 0, lost = 0, gf = 0, ga = 0;
                var form = new List<string>();

                foreach (var m in teamMatches)
                {
                    bool isHome = m.HomeTeamName == team.TeamName;
                    int myScore = isHome ? m.FullTimeScoreHome!.Value : m.FullTimeScoreAway!.Value;
                    int oppScore = isHome ? m.FullTimeScoreAway!.Value : m.FullTimeScoreHome!.Value;

                    played++;
                    gf += myScore;
                    ga += oppScore;

                    if (myScore > oppScore) { won++; form.Add("W"); }
                    else if (myScore == oppScore) { drawn++; form.Add("D"); }
                    else { lost++; form.Add("L"); }
                }

                standings.Add(new StandingsViewModel
                {
                    TeamId = team.TeamId,
                    TeamName = team.TeamName,
                    TeamLogoUrl = team.TeamLogoUrl,
                    Played = played,
                    Won = won,
                    Drawn = drawn,
                    Lost = lost,
                    GoalsFor = gf,
                    GoalsAgainst = ga,
                    Points = won * 3 + drawn,
                    Form = form.TakeLast(5).ToList()
                });
            }

            // Sıralama: puan > averaj > atılan gol
            var ordered = standings
                .OrderByDescending(x => x.Points)
                .ThenByDescending(x => x.GoalDiff)
                .ThenByDescending(x => x.GoalsFor)
                .ToList();

            ViewBag.MostGoalTeam = ordered.OrderByDescending(x => x.GoalsFor).FirstOrDefault();
            ViewBag.BestDefenseTeam = ordered
                .Where(x => x.Played > 0)
                .OrderBy(x => x.GoalsAgainst)
                .FirstOrDefault();
            ViewBag.LeaderTeam = ordered.FirstOrDefault();

          

            return View(ordered);
        }
    }
}
