using System.Collections.Generic;

namespace ChatBot.Client.Library.Platforms.ChatFuelFiles
{
    public class ChatFuel
    {
        public List<ChatFuelMessage> messages { get; set; } = new List<ChatFuelMessage>();
        public Dictionary<string, object> set_attributes { get; set; } = new Dictionary<string, object>();
    }
}
