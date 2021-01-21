using System.Collections.Generic;

namespace ChatBot.Client.Library.Platforms.ChatFuelFiles
{
    public class ChatFuelButton
    {
        internal class ButtonTypes
        {
            internal const string phone_number = "phone_number";
            internal const string show_block = "show_block";
            internal const string web_url = "web_url";
            internal const string json_plugin_url = "json_plugin_url";
        }

        public string title { get; private set; }
        public string type { get; private set; }
        public string url { get; private set; }
        public List<string> block_names { get; private set; }
        public object set_attributes { get; private set; }
        public string webview_height_ratio { get; private set; }
        public string phone_number { get; private set; }

        public static ChatFuelButton ShowBlockButtons(string title, List<string> block_names)
        {
            return new ChatFuelButton()
            {
                type = ButtonTypes.show_block,
                block_names = block_names,
                title = title
            };
        }
    }
}
