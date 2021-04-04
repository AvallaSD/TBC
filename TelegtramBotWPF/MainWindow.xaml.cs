using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using TelegramBot; 

namespace TelegtramBotWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BotClient client = new BotClient("");
        long SelectedChat { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            EventHandler<MessageEventArgs> handler = MessageListener;
            client.AddListener(handler);
        }

        public void MessageListener(object sender, MessageEventArgs e)
        {
            var message = e.Message;
            var messageInfo = new MessageInfo(message);
            Dispatcher.Invoke(() =>
            {                
                messagesListView.Items.Add(messageInfo);
            });
        }

        private void messagesListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedMessage = e.AddedItems[0] as MessageInfo;
            SelectedChat = selectedMessage.Message.Chat.Id;
            textBlock.Text = selectedMessage.Sender;
        }

        private void sendMessageBtn_Click(object sender, RoutedEventArgs e)
        {
            var message = client.SendMessage(SelectedChat, textBox.Text).Result;
            textBox.Text = "";
            var messageInfo = new MessageInfo(message, $"Я --> {textBlock.Text}");
            Dispatcher.Invoke(() =>
            {
                messagesListView.Items.Add(messageInfo);
            });
        }

        private void exitBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void saveMessagesBtn_Click(object sender, RoutedEventArgs e)
        {
            var messages = messagesListView.Items.OfType<MessageInfo>().Select(x =>
            {
                x.Message = null;
                return x;
            });

            using (StreamWriter stream = new StreamWriter("test.json"))
            {
                stream.WriteLine(JsonConvert.SerializeObject(messages));
            }
            MessageBox.Show("Сохранено");
        }

        private void showMEssageBtn_Click(object sender, RoutedEventArgs e)
        {
            string message = "";
            if (System.IO.File.Exists("test.json"))
            {
                var infos = JsonConvert.DeserializeObject<IEnumerable<MessageInfo>>(System.IO.File.ReadAllText("test.json"));
                foreach (var info in infos)
                {
                    message += $"{info.Date}\n{info.Sender}:\n{info.Text}\n";
                }
            }
            else
            {
                message = "Нет сохраненных сообщений";
            }
            
            MessageBox.Show(message);         
        }
    }
}
