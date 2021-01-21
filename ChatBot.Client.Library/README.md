# ChatBot.Client.Library

To create a ChatBotClient Instance.

```C#
ChatBotClient chatBot = new ChatBotClient();
```

This uses a chaining method for the order of blocks.

```C#
ChatFuel chatFuel = chatBot
  .AddTextBlock("Hello World!")
  .AddTextBlock("This is a sample message.")
  .AddImageBlock("http://www.sampleimage.com/default.png")
  .ChatFuel();
```
