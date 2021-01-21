using ChatBot.Client.Library.Platforms.ChatFuelFiles;
using ChatBot.Client.Library.Platforms.LetsChatPHFiles;
using System.Collections.Generic;
using System.Reflection;

namespace ChatBot.Client.Library
{
    public class ChatBotClient
    {
        List<Dictionary<string, object>> MessageBlocks { get; set; } = new List<Dictionary<string, object>>();
        Dictionary<string, object> Attributes { get; set; } = new Dictionary<string, object>();

        /// <summary>
        /// Adding a TextBlock for chatbot.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public ChatBotClient AddTextBlock(string text)
        {
            MessageBlocks.Add(new Dictionary<string, object>
            {
                { "text", text }
            });
            return this;
        }

        /// <summary>
        /// Adding a ImageBlock for chatbot.
        /// </summary>
        /// <param name="imgUrl"></param>
        /// <returns></returns>
        public ChatBotClient AddImageBlock(string imgUrl)
        {
            MessageBlocks.Add(new Dictionary<string, object>
            {
                { "image", imgUrl }
            });
            return this;
        }

        /// <summary>
        /// Adding a HorizontalListBlock for chatbot
        /// </summary>
        /// <param name="elements"></param>
        /// <returns></returns>
        public ChatBotClient AddHorizontalListBlock(List<ChatBotElement> elements)
        {
            MessageBlocks.Add(new Dictionary<string, object>
            {
                { "cards", elements }
            });
            return this;
        }

        public ChatBotClient SetAttributes(object args)
        {
            foreach (PropertyInfo propertyInfo in args.GetType().GetProperties())
            {
                var name = propertyInfo.Name;
                var value = propertyInfo.GetValue(args);
                Attributes.Add(name, value);
            }
            return this;
        }

        public ChatFuel ChatFuel()
        {
            var chatFuel = new ChatFuel();

            // Setting Attributes API for ChatFuel.
            if (Attributes.Count > 0) chatFuel.set_attributes = Attributes;
            else chatFuel.set_attributes = null;

            // Setting MessageBlocks API for ChatFuel.
            if (MessageBlocks.Count > 0)
            {
                foreach (var item in MessageBlocks)
                {
                    // Creating TextBlock API for ChatFuel.
                    if (item.TryGetValue("text", out object text))
                    {
                        chatFuel.messages.Add(new ChatFuelMessage
                        {
                            text = text.ToString()
                        });
                    }

                    // Creating ImageBlock API for ChatFuel.
                    else if (item.TryGetValue("image", out object url))
                    {
                        chatFuel.messages.Add(new ChatFuelMessage
                        {
                            attachment = new Dictionary<string, object>
                            {
                                { "type", "image" },
                                { "payload", new { url } }
                            }
                        });
                    }

                    // Creating HorizontalListBlock  API for ChatFuel.
                    else if (item.TryGetValue("cards", out object elements))
                    {
                        chatFuel.messages.Add(new ChatFuelMessage
                        {
                            attachment = new Dictionary<string, object>
                            {
                                { "type", "template" },
                                { "payload", new
                                    {
                                        template_type = "generic",
                                        image_aspect_ratio = "square",
                                        elements
                                    }
                                }
                            }
                        });
                    }
                }
            }
            else chatFuel.messages = null;
            return chatFuel;
        }

        public LetsChatPH LetsChatPH()
        {
            var letsChatPh = new LetsChatPH();

            // Setting UserAttributes API for LetsChatPH.
            if (Attributes.Count > 0) letsChatPh.actions = new List<LetsChatPHAction>
            {
                new LetsChatPHAction
                {
                    type = "set_variable",
                    data = Attributes
                }
            };
            else letsChatPh.actions = null;

            if (MessageBlocks.Count > 0)
            {
                foreach (var item in MessageBlocks)
                {
                    // Creating TextBlock API for LetsChatPH.
                    if (item.TryGetValue("text", out object text))
                    {
                        letsChatPh.messages.Add(new LetsChatPHMessage
                        {
                            text = text.ToString()
                        });
                    }

                    // Creating ImageBlock API for LetsChatPH.
                    if (item.TryGetValue("image", out object image))
                    {
                        letsChatPh.messages.Add(new LetsChatPHMessage
                        {
                            image = image.ToString()
                        });
                    }
                }
            }
            else letsChatPh.messages = new List<LetsChatPHMessage>();

            return letsChatPh;
        }
    }
}
