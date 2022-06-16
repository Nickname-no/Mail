using OpenPop.Mime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mail
{
    public class MailInfo
    {
        public string From { get; set; }
        public string Subject { get; set; }
        public string Date { get; set; }

        public MailInfo(Message message)
        {
            this.From = message.Headers.From.ToString();
            this.Subject = message.Headers.Subject.ToString();
            this.Date = message.Headers.Date.ToString();
        }

    }
}
