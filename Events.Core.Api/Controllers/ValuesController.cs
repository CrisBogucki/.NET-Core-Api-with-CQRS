using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Events.Core.Api.CQRS;
using Events.Core.Api.CQRS.Command;
using Events.Core.Api.CQRS.Event;
using Events.Core.Api.CQRS.Query;
using Events.Core.Api.Domain.Command;
using Events.Core.Api.Domain.Event;
using Events.Core.Api.Domain.Query;
using Microsoft.AspNetCore.Mvc;

namespace Events.Core.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ICommandBus _commandBus;
        private readonly IQueryBus _queryBus;
        private readonly IEventBus _eventsBus;


        public ValuesController(ICommandBus commandBus, IQueryBus queryBus, IEventBus eventsBus)
        {
            _commandBus = commandBus;
            _queryBus = queryBus;
            _eventsBus = eventsBus;
        }


        // GET api/values/msg
        [HttpGet("{msg}")]
        public async Task<ActionResult> Get(string msg)
        {
            Console.WriteLine("-> command");
            MessageCommand _msg = new MessageCommand() { Message = "My message 1", Title = "Title 1", Delay = 5000};
            _commandBus.SendCommandAsync(_msg);

            Console.WriteLine("-> query");
            IResponse c = await _queryBus.SendQueryAsync(new MessageQuery {Id = 99});

            var __msg = new MessageEvent()
            {
                Date = DateTime.Now, // get date from regex
                Message = " to events"
            };
            Console.WriteLine("-> event");
            await _eventsBus.PublishEventAsync(__msg);
            
            return Ok(c);
        }
    }
}