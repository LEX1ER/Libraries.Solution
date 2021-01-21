using System.Collections.Generic;

namespace ChatBot.Client.Library.Platforms.ChatFuelFiles
{
    public class ChatFuelElement
    {
        public string title { get; set; }
        public string image_url { get; set; }
        public string subtitle { get; set; }
        public List<ChatFuelButton> buttons { get; set; }
    }
}
