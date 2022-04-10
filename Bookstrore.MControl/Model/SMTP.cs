using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Bookstrore.MControl.Model
{
    public class SMTP
    {
        #region Fields
        private const string _FROM = "Bookstore.Net@yandex.ru";
        private const string _PASS = "yvikffakkkrcuxdm";
        private readonly string _TO;
        private SmtpClient _client = new SmtpClient{Host = "smtp.yandex.ru",Port = 25};
        private MailMessage _message = new MailMessage();

        #endregion

        public SMTP(string mail)
        {
            _TO=mail;
        }

        private void ConfigSMTPClient()
        {
            _client.EnableSsl = true;
            _client.DeliveryMethod = SmtpDeliveryMethod.Network;
            _client.UseDefaultCredentials = false;
            _client.Credentials = new NetworkCredential(_FROM, _PASS);
        }
        private void ConfigMessage(string theme, string message)
        {
            _message.From = new MailAddress(_FROM);
            _message.To.Add(_TO);
            _message.Subject = theme;
            _message.Body = message;

        }

        private void SendMessage(string theme,string message)
        {
            ConfigSMTPClient();
            ConfigMessage(theme,message);
            _client.Send(_message);
        }

        public static void SendMessage(string mail,string theme,string text)
        {
            SmtpClient client = new SmtpClient { Host = "smtp.yandex.ru", Port = 25 };
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(_FROM, _PASS);
            MailMessage message = new MailMessage();
            message.From = new MailAddress(_FROM);
            message.To.Add(mail);
            message.Subject=theme;
            message.Body = text;
            client.Send(message);
        }
    }
}
