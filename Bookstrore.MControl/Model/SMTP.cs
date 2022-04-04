using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Bookstrore.MControl.Model
{
    public class SMTP
    {
        //переменная - адрес отправителя
        private MailAddress _sender = new MailAddress("Bookstore.Net@yandex.ru","Книжный магазин .NET");
        
        //переменная - адрес получателя
        private readonly MailAddress _resipient;

        //TODO: Может быть стоит использовать enum?
        private readonly MailMessage _message;

        private enum _messageType
        {
            
        }

    }
}
