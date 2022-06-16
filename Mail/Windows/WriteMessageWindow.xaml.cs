using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Mail
{
    /// <summary>
    /// Логика взаимодействия для WriteMessageWindow.xaml
    /// </summary>
    public partial class WriteMessageWindow : Window
    {
        public WriteMessageWindow()
        {
            InitializeComponent();
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            MailAddress from = new MailAddress(MailClient.Mail);
            MailAddress to = new MailAddress(ToTextBox.Text);
            MailMessage m = new MailMessage(from, to);
            m.Subject = SubjectTextBox.Text;
            m.Body = TextMessage.Text;
            SmtpClient smtp = new SmtpClient(MailClient.Mail, 587);
            smtp.Credentials = new NetworkCredential(MailClient.Mail, MailClient.Password);
            
            smtp.Send(m);
        }
    }
}
