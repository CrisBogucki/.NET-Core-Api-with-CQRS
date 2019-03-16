using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Events.Core.Api.CQRS.Command;
using Events.Core.Api.Domain.Command;
using Microsoft.AspNetCore.Mvc;

namespace Events.Core.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ICommandBus _commandBus;

        public ValuesController(ICommandBus commandBus)
        {
            _commandBus = commandBus;
        }
        

        // GET api/values/msg
        [HttpGet("{msg}")]
        public async Task<ActionResult> Get(string msg)
        {

             await _commandBus.SendCommandAsync(new MessageCommand()
                {Message = "My mesage 1", Title = "Title 1", Delay = 5000});
             await _commandBus.SendCommandAsync(new MessageCommand()
                {Message = "My mesage 1", Title = "Title 2", Delay = 7000});
             await _commandBus.SendCommandAsync(new MessageCommand()
                {Message = "My mesage 1", Title = "Title 3", Delay = 3000});
             await _commandBus.SendCommandAsync(new MessageCommand()
                {Message = "My mesage 1", Title = "Title 4", Delay = 4000});
            
            return Ok();
        }
    }
}