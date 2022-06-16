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
using System.Windows.Shapes;

namespace Mail
{
    /// <summary>
    /// Логика взаимодействия для DetailMessageWindow.xaml
    /// </summary>
    public partial class DetailMessageWindow : Window
    {
        public DetailMessageWindow(string from,string subject, string date, string text)
        {
            InitializeComponent();
            From.Content = "From: " + from;
            Subject.Content = "Subject: " + subject;
            Date.Content = "Date: " + date;
            Text.Text = text;
        }
    }
}
