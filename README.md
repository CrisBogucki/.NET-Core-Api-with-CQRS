# Events Core Api with CQRS 
Segregation with events, comands and queries

![](http://www.ouarzy.com/wp-content/uploads/2016/09/cqsr_pattern.png)

## Using Command
add commandbus in constructor use dependency inject
```
private readonly ICommandBus commandBus;

public MyController(ICommandBus commandBus)
{
    this.commandBus = commandBus;
}
```

method 
using by async
```      
public async Task RunCommandAsync()
{
    MessageCommand _msg = new MessageCommand() { ... };
    this.commandBus.SendCommandAsync(_msg);
}
```
or void synchro
```
public void RunCommand()
{
    MessageCommand _msg = new MessageCommand() { ... };
    this.commandBus.SendCommand(_msg);
}
```

## Using Query
add querybus in constructor use dependency inject
```
private readonly IQueryBus queryBus;

public MyController(IQueryBus queryBus)
{
    this.queryBus = queryBus;
}
```

method 
using by async
```      
public async Task RunQueryAsync()
{
    MessageQuery _msg = new MessageQuery() { ... };
    var result = await this.queryBus.SendQueryAsync(_msg);
}
```
or void synchro
```
public void RunQuery()
{
    MessageQuery _msg = new MessageQuery() { ... };
    var result = this.queryBus.SendQuery(_msg);
}
```

## Using Events
add eventsbus in constructor use dependency inject
```
private readonly IEventBus eventsBus;

public MyController(IEventBus eventsBus)
{
    this.eventsBus = eventsBus;
}
```

method 
using by async
```      
public async Task RunEventsAsync()
{
    MessageEvent _msg = new MessageEvent() { ... };
    await this.eventsBus.PublishEventAsync(msg);
}
```
or void synchro
```
public void RunEvents()
{
    MessageEvent _msg = new MessageEvent() { ... };
    this.eventsBus.PublishEvent(msg);
}
```


CQRS is not Events Sourcing (which is not Event Storming)

Some people understand CQRS/ES as a single architecture paradigm. It’s actually two different paradigms, even is they were brought out together .

CQRS is about segregation of the commands and the queries in a system. It is nothing but Single Responsibility Principle (SRP) apply to separate the decisions from the effects. It comes from CQS.

Event Sourcing (ES) is about storing immutable events as the source of truth to derive any state of the whole system at any time.

Both paradigms work well together (Greg Young calls them “symbiotic”). But we can do CQRS without ES, and we can do ES without CQRS.

And just because I heard the confusion a few times, Event Storming is not Event Sourcing. It is not an architecture paradigm. Event Storming is a way to crunch knowledge with the business in an event driven approach, but it is not technical at all. It is a convention to talk with other people using post-its to represent business events.
