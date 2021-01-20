# SignalR.Client.Library

Dependency of this project.

```#
using Microsoft.AspNetCore.SignalR.Client;
```

Connect to your own SignalR Server.

```c#
SignalR signalR = new SignalR();
string url = "https://www.mysignalrhost.com/hubs/myhub";
object queryParams = new 
{
   // your query parameters here.
};

HubConnection signalRConnection = signalR
  .Url(url)
  .QueryParams(queryParams)
  .Connect();
```

Everytime a SignalR HubContext is triggered.

```c#
signalRConnection.On<string, myObject>("myTriggerString", (user, data) =>
{
  // your code here.
});
```

