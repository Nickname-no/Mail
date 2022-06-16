using OpenPop.Mime;
using OpenPop.Pop3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mail
{
    public static class MailClient
    {
        public static string Mail { get; set; }
        public static string Password { get; set; }
        private static Pop3Client Client { get; set; }

        public static void SignIn()
        {
            Client = new Pop3Client();
            Client.Connect("pop.mail.ru", 995, true);
            Client.Authenticate(Mail, Password, AuthenticationMethod.UsernameAndPassword);
        }

        public static bool IsConnected() => Client.Connected;

        public static void SignOut()
        {
            Mail = string.Empty;
            Password = string.Empty;
            Client.Dispose();
        }

        public static List<Message> GetMasseges()
        {
            if (IsConnected())
            {
                int messageCount = Client.GetMessageCount();
                List<Message> allMessages = new List<Message>(messageCount);

                for (int i = 5; i > 0; i--)
                {
                    try
                    {
                        allMessages.Add(Client.GetMessage(i));
                        //Message message = Client.GetMessage(i);
                    }
                    catch { }
                }

                return allMessages;
            }
            else return null;
        }
    }
}
