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
