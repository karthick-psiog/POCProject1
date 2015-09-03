using BusinessObjects.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.BAL
{
    class EmailService:IEmailService
    {
        string _from;
        string _to;
        string _subject;
        string _message;
        string _host;
        int _port;
        public EmailService(){ }
        public EmailService(int port,string host) {
            _port = port;
            _host = host;
        }

        public string From { get { return _from; } set { _from = value; } }
        public string To { get { return _to; } set { _to = value; } }
        public string Subject { get { return _subject; } set { _subject = value; } }
        public string Message { get { return _message; } set { _message = value; } }

        public bool triggerEmail()
        {
            using (MailMessage mail = new MailMessage(From, To)) 
            { 
                SmtpClient client = new SmtpClient();
                client.Port = _port;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Host = _host;
                mail.Subject = Subject;
                try
                {
                    mail.Body = Message;
                }
                catch (Exception ex)
                {
                   
                }
                client.Send(mail);
                return true; 
            }
        
        }

        public bool emailLog(AuditLog AL, EmailLog EL)
        {
             DataStore.writeEmailLog( EL, AL);
             return true;
        }

    }
}
