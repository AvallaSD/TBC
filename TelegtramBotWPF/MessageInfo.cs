using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegtramBotWPF
{
    class MessageInfo
    {
        public MessageInfo(Message message)
        {
            Message = message;
            Date = message.Date;
            Sender = $"{message.From.FirstName} {message.From.LastName}";
            Text = message.Text;
        }
        public MessageInfo(Message message, string sender)
        {
            Message = message;
            Date = message.Date;
            Sender = sender;
            Text = message.Text;
        }

        [JsonConstructor]
        public MessageInfo(Message message, DateTime date, string sender, string text)
        {
            Message = message;
            Date = date;
            Sender = sender;
            Text = text;
        }

        public Message Message { get; set; }
        public DateTime Date { get; set; }
        public string Sender { get; set; }
        public string Text { get; set; }

    }
}
