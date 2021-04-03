using System;
using System.Collections.Generic;
using Telegram.Bot;

namespace TelegramBot
{
    class Program
    {
        static void Main()
        {
            BotClient client = new BotClient("");
            while (true)
            {
                Console.WriteLine("Бот работает. Для прекращения введите exit:");
                if (Console.ReadLine() == "exit")
                {
                    break;
                }
            }
        }
        
        
        
    }
}
