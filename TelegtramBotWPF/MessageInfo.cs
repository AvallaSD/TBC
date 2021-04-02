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
        public MessageInfo(Message message, string reciever)
        {
            Message = message;
            Date = message.Date;
            Sender = reciever;
            Text = message.Text;
        }

        public Message Message { get; set; }
        public DateTime Date { get; set; }
        public string Sender { get; set; }
        public string Text { get; set; }
    }
}
