using OpenPop.Mime;
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

namespace Mail
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Message> Messages { get; set; } = new List<Message>();
        public MainWindow()
        {
            InitializeComponent();
            foreach (Message message in MailClient.GetMasseges())
            {
                Messages.Add(message);
                ListMessages.Items.Add(new MailInfo(message));
            }
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MailInfo mailInfo = (MailInfo)ListMessages.SelectedItem;
            Message selectedMessage = Messages.FirstOrDefault(x => x.Headers.Date.ToString() == mailInfo.Date &&
                                                              x.Headers.From.ToString() == mailInfo.From &&
                                                              x.Headers.Subject.ToString() == mailInfo.Subject);
            if (selectedMessage != null)
            {
                MessagePart mpPlain = selectedMessage.FindFirstPlainTextVersion();
                string body = string.Empty;
                
                if (mpPlain != null)
                {
                    Encoding enc = mpPlain.BodyEncoding;
                    body = enc.GetString(mpPlain.Body); //получаем текст сообщения
                }

                DetailMessageWindow detailMessageWindow = new DetailMessageWindow(selectedMessage.Headers.From.ToString(),
                                                                                  selectedMessage.Headers.Subject.ToString(),
                                                                                  selectedMessage.Headers.Date.ToString(),
                                                                                  body);
                detailMessageWindow.Show();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WriteMessageWindow writeMessageWindow = new WriteMessageWindow();
            writeMessageWindow.Show();
        }
    }
}
