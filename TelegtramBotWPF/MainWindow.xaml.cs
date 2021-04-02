using System;
using System.Collections.Generic;
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
using TelegramBot; 

namespace TelegtramBotWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BotClient client = new BotClient("1459208947:AAF4btGXyWkEQIW21eMMs0t38fWtnY6fGyQ");
        
        public MainWindow()
        {
            InitializeComponent();
            EventHandler<MessageEventArgs> handler = MessageListener;
            client.AddListener(handler);
        }
        
        public void MessageListener(object sender, MessageEventArgs e)
        {
            MessageBox.Show(e.Message.Text);
        }
    }
}
