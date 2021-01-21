using System.Collections.Generic;

namespace ChatBot.Client.Library.Platforms.ChatFuelFiles
{
    public class ChatFuelMessage
    {
        public string text { get; set; }
        public Dictionary<string, object> attachment { get; set; }
    }
}
