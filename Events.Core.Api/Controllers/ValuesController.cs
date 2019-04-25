using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Events.Core.Api.CQRS;
using Events.Core.Api.CQRS.Command;
using Events.Core.Api.CQRS.Query;
using Events.Core.Api.Domain.Command;
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

        public ValuesController(ICommandBus commandBus, IQueryBus queryBus)
        {
            _commandBus = commandBus;
            _queryBus = queryBus;
        }


        // GET api/values/msg
        [HttpGet("{msg}")]
        public async Task<ActionResult> Get(string msg)
        {
            Console.WriteLine("-> command");
            _commandBus.SendCommandAsync(new MessageCommand(){Message = "My mesage 1", Title = "Title 1", Delay = 5000});

            Console.WriteLine("-> query");
            IResponse c = await _queryBus.SendQueryAsync(new MessageQuery() {Id = 99});

            return Ok(c);
        }
    }
}