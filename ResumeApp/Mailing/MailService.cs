using Microsoft.Extensions.Configuration;
using System;
using System.Net.Mail;
using System.Text;


namespace ResumeApp.Mailing
{
    public class MailService
    {
        private readonly string email;
        private readonly string subject;
        private readonly string comment;
        private readonly IConfiguration _config;

        public MailService(string Email, string Subject, string Comment, IConfiguration config)
        {
            email = Email;
            subject = Subject;
            comment = Comment;
            _config = config;
        }

        public void SendEmail()
        {
            string to = "osasfrank246@gmail.com"; //To address    
            string from = email; //From address    
            MailMessage message = new MailMessage(from, to);

            string mailbody = comment;
            message.Subject = subject;
            message.Body = mailbody;
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;
            var client = Configure();
            try
            {
               
                client.Send(message);
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                client.Dispose();
            }
        }
        private SmtpClient Configure()
        {
            var server = _config.GetValue<string>("EmailConfiguration:SmtpServer");
            var port = _config.GetValue<int>("EmailConfiguration:SmtpPort");
            var emailId = _config.GetValue<string>("EmailConfiguration:SmtpUsername");
            var password = _config.GetValue<string>("EmailConfiguration:SmtpPassword");
            
            SmtpClient client = new SmtpClient(server, port); //Gmail smtp    
            System.Net.NetworkCredential basicCredential1 = new
            System.Net.NetworkCredential(emailId, password);
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = basicCredential1;
            return client;
        }
    }
}
