using System;
using System.Collections.Generic;
using System.Text;

namespace ChatBot.Client.Library.Platforms.LetsChatPHFiles
{
    public class LetsChatPH
    {
        public List<LetsChatPHMessage> messages { get; set; } = new List<LetsChatPHMessage>();
        public List<LetsChatPHAction> actions { get; set; } = new List<LetsChatPHAction>();
    }
}
