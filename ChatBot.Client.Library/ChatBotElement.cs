using System.Collections.Generic;

namespace ChatBot
{
    public class ChatBotElement
    {
        public string title { get; set; }
        public string image_url { get; set; }
        public string subtitle { get; set; }
        public List<ChatBotButton> buttons { get; set; }
    }
}
