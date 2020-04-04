﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using W3ChampionsStatisticService.Services;

namespace W3ChampionsStatisticService.MatchEvents
{
    [ApiController]
    [Route("api/matchevents")]
    public class MatchEventsController : ControllerBase
    {
        private readonly InsertMatchEventsCommandHandler _handler;
        private TrackingService _trackingService;

        public MatchEventsController(InsertMatchEventsCommandHandler handler, TrackingService trackingService)
        {
            _handler = handler;
            _trackingService = trackingService;
        }

        [HttpPost]
        public async Task<IActionResult> PushEvents(
            string authorization,
            [FromBody] IList<MatchFinishedEvent> events
            )
        {
            if (authorization != "D920618D-2296-4631-A6E4-333CCCDC04DE")
            {
                _trackingService.TrackUnauthorizedRequest(authorization, this);
                return Unauthorized("Sorry H4ckerb0i");
            }

            await _handler.Insert(events);
            return Ok();
        }


    }
}