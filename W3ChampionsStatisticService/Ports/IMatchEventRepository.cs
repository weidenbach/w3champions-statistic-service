﻿using System.Collections.Generic;
using System.Threading.Tasks;
using W3ChampionsStatisticService.Ladder;
using W3ChampionsStatisticService.MatchEvents;

namespace W3ChampionsStatisticService.Ports
{
    public interface IMatchEventRepository
    {
        Task Insert(List<MatchFinishedEvent> events);
        Task<List<MatchFinishedEvent>> Load(string lastObjectId,  int pageSize = 100);
        Task Insert(List<MatchStartedEvent> events);
        Task Insert(List<LeagueConstellationChangedEvent> events);
        Task Insert(List<RankingChangedEvent> events);
        Task<RankingChangedEvent> LoadRank(int ladderId, int gateWay);
        Task Insert(List<Rank> events);
    }
}