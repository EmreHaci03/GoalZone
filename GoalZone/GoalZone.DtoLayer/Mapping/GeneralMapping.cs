using AutoMapper;
using GoalZone.DtoLayer.DTOS.DefaultDto;
using GoalZone.DtoLayer.DTOS.FootballMatchDto;
using GoalZone.DtoLayer.DTOS.MatchEventDto;
using GoalZone.DtoLayer.DTOS.MatchStatisticDto;
using GoalZone.DtoLayer.DTOS.NewsDto;
using GoalZone.DtoLayer.DTOS.PlayerDto;
using GoalZone.DtoLayer.DTOS.StadiumDto;
using GoalZone.DtoLayer.DTOS.TeamDto;
using GoalZone.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoalZone.DtoLayer.Mapping
{
    public class GeneralMapping:Profile
    {
        public GeneralMapping()
        {
            CreateMap<Team, ResultTeamDto>()
               .ForMember(dest => dest.StadiumName, opt => opt.MapFrom(src => src.Stadium.StadiumName))
                .ForMember(dest => dest.StadiumName, opt => opt.MapFrom(src => src.Stadium.StadiumName));
            CreateMap<Team, GetTeamByIdDto>()
                .ForMember(dest => dest.StadiumName, opt => opt.MapFrom(src => src.Stadium.StadiumName));
            CreateMap<Team, CreateTeamDto>().ReverseMap();
            CreateMap<Team, UpdateTeamDto>().ReverseMap();

            CreateMap<Stadium, ResultStadiumDto>().ReverseMap();
            CreateMap<Stadium, CreateStadiumDto>().ReverseMap();
            CreateMap<Stadium, UpdateStadiumDto>().ReverseMap();
            CreateMap<Stadium, GetStadiumByIdDto>().ReverseMap();


            CreateMap<Player, ResultPlayerDto>()
                .ForMember(dest => dest.TeamName, opt => opt.MapFrom(src => src.Team.TeamName))
                .ForMember(dest => dest.TeamImageUrl, opt => opt.MapFrom(src => src.Team.TeamLogoUrl));

            CreateMap<Player, CreatePlayerDto>().ReverseMap();
            CreateMap<Player, GetPlayerByIdDto>()
                 .ForMember(dest => dest.TeamName, opt => opt.MapFrom(src => src.Team.TeamName)); 
            CreateMap<Player, UpdatePlayerDto>().ReverseMap();

            CreateMap<MatchStatistic, ResultMatchStatisticDto>()
     .ForMember(dest => dest.FootballMatch, opt => opt.MapFrom(src => src.FootballMatch.HomeTeam.TeamName+" "+
     src.FootballMatch.AwayTeam.TeamName 
     +" (Hafta " + src.FootballMatch.Week + ")"));
            CreateMap<MatchStatistic, CreateMatchStatisticDto>().ReverseMap();
            CreateMap<MatchStatistic, UpdateMatchStatisticDto>().ReverseMap();
            CreateMap<MatchStatistic, GetMatchStatisticByIdDto>()
                 .ForMember(dest => dest.FootballMatch, opt => opt.MapFrom(src => src.FootballMatch.HomeTeam.TeamName + " " +
                 src.FootballMatch.AwayTeam.TeamName));
    


            CreateMap<MatchEvent, ResultMatchEventDto>()
    .ForMember(dest => dest.FootballMatchName,
               opt => opt.MapFrom(src =>
                   src.FootballMatch.HomeTeam.TeamName + " - " +
                   src.FootballMatch.AwayTeam.TeamName))
    .ForMember(dest => dest.EventType,
               opt => opt.MapFrom(src => src.EventType.ToString()));

            CreateMap<MatchEvent, CreateMatchEventDto>().ReverseMap();

            CreateMap<MatchEvent, GetMatchEventByFootballIdDto>()
                .ForMember(dest => dest.PlayerName,
                opt => opt.MapFrom(src => src.PlayerName))
                .ForMember(dest => dest.FootballMatchName,
               opt => opt.MapFrom(src =>
                   src.FootballMatch.HomeTeam.TeamName + " - " +
                   src.FootballMatch.AwayTeam.TeamName))
                .ForMember(dest => dest.HomeTeam,
                opt => opt.MapFrom(src => src.FootballMatch.HomeTeam.TeamName))
                    .ForMember(dest => dest.AwayTeam,
                opt => opt.MapFrom(src => src.FootballMatch.AwayTeam.TeamName));

            CreateMap<MatchEvent, GetMatchEventByIdDto>()
                .ForMember(dest => dest.FootballMatchId, opt => opt.MapFrom(src => src.FootballMatch.FootballMatchId));
            CreateMap<MatchEvent, UpdateMatchEventDto>()
                .ForMember(dest => dest.EventType, opt => opt.MapFrom(src => src.EventType.ToString()));



            CreateMap<FootballMatch, ResultFootballMatchDto>()
                .ForMember(dest => dest.HomeTeamName,
               opt => opt.MapFrom(src => src.HomeTeam.TeamName))
                .ForMember(dest => dest.Capacity,
               opt => opt.MapFrom(src => src.HomeTeam.Stadium.Capacity))
                 .ForMember(dest => dest.City,
               opt => opt.MapFrom(src => src.HomeTeam.Stadium.City))
                .ForMember(dest => dest.HomeTeamLogoUrl,
               opt => opt.MapFrom(src => src.HomeTeam.TeamLogoUrl))
                .ForMember(dest => dest.AwayTeamName,
               opt => opt.MapFrom(src => src.AwayTeam.TeamName))
                .ForMember(dest => dest.AwayTeamLogoUrl,
               opt => opt.MapFrom(src => src.AwayTeam.TeamLogoUrl))
                .ForMember(dest => dest.StadiumName,
               opt => opt.MapFrom(src => src.HomeTeam.Stadium.StadiumName))
                .ForMember(dest => dest.MatchStatus,
               opt => opt.MapFrom(src => src.MatchStatus.ToString()));

            CreateMap<FootballMatch, GetFeatureMatchDto>()
                .ForMember(dest => dest.HomeTeamName,
                opt => opt.MapFrom(src => src.HomeTeam.TeamName))
                .ForMember(dest => dest.HomeTeamLogoUrl,
                opt => opt.MapFrom(src => src.HomeTeam.TeamLogoUrl))
                .ForMember(dest => dest.AwayTeamName,
                opt => opt.MapFrom(src => src.AwayTeam.TeamName))
                .ForMember(dest => dest.AwayTeamLogoUrl,
                opt => opt.MapFrom(src => src.AwayTeam.TeamLogoUrl))
                .ForMember(dest => dest.StadiumName,
                opt => opt.MapFrom(src => src.HomeTeam.Stadium.StadiumName))
                .ForMember(dest => dest.MatchStatus,
                opt => opt.MapFrom(src => src.MatchStatus.ToString()));

            CreateMap<FootballMatch, ResultLiveMatchDto>()
            .ForMember(dest => dest.HomeTeamName,
            opt => opt.MapFrom(src => src.HomeTeam.TeamName))
            .ForMember(dest => dest.HomeTeamLogoUrl,
            opt => opt.MapFrom(src => src.HomeTeam.TeamLogoUrl))
            .ForMember(dest => dest.AwayTeamName,
            opt => opt.MapFrom(src => src.AwayTeam.TeamName))
            .ForMember(dest => dest.AwayTeamLogoUrl,
            opt => opt.MapFrom(src => src.AwayTeam.TeamLogoUrl))
            .ForMember(dest => dest.StadiumName,
            opt => opt.MapFrom(src => src.HomeTeam.Stadium.StadiumName))
            .ForMember(dest => dest.MatchStatus,
            opt => opt.MapFrom(src => src.MatchStatus.ToString()));

            CreateMap<FootballMatch, GetFootballMatchByIdDto>()
                .ForMember(dest => dest.HomeTeamName, opt => opt.MapFrom(src => src.HomeTeam.TeamName))
                .ForMember(dest => dest.HomeTeamLogoUrl, opt => opt.MapFrom(src => src.HomeTeam.TeamLogoUrl))
                .ForMember(dest => dest.AwayTeamName, opt => opt.MapFrom(src => src.AwayTeam.TeamName))
                .ForMember(dest => dest.AwayTeamLogoUrl, opt => opt.MapFrom(src => src.AwayTeam.TeamLogoUrl))
                .ForMember(dest => dest.StadiumName, opt => opt.MapFrom(src => src.HomeTeam.Stadium.StadiumName))
                .ForMember(dest => dest.MatchStatus, opt => opt.MapFrom(src => src.MatchStatus.ToString()));
            CreateMap<FootballMatch, UpdateFootballMatchDto>().ReverseMap();
            CreateMap<FootballMatch, CreateFootballMatchDto>().ReverseMap();



            CreateMap<News, ResultNewsDto>()
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.ToString()))
                 .ForMember(dest => dest.RelatedTeamLogo, opt => opt.MapFrom(src => src.RelatedTeam.TeamLogoUrl))
                  .ForMember(dest => dest.RelatedTeamName, opt => opt.MapFrom(src => src.RelatedTeam.TeamName));
            CreateMap<News, CreateNewsDto>().ReverseMap();
            CreateMap<News, GetNewsByIdDto>()
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.ToString()))
                .ForMember(dest => dest.RelatedTeamName, opt => opt.MapFrom(src => src.RelatedTeam.TeamName))
                .ForMember(dest => dest.RelatedTeamLogo, opt => opt.MapFrom(src => src.RelatedTeam.TeamLogoUrl));
            CreateMap<UpdateNewsDto, News>()
                .ForMember(dest => dest.PublishDate, opt => opt.Ignore())
                 .ForMember(dest => dest.ViewCount, opt => opt.Ignore());
        }
    }
}
