using Experimental.System.Messaging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Common_Layer.Models
{
    public class Msmq
    {
        MessageQueue messageQueue = new MessageQueue();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="token"></param>
        public void SendMessage(string token)
        {
            messageQueue.Path = @".\private$\Tokens";
            try
            {
                if (!MessageQueue.Exists(messageQueue.Path))
                {
                    MessageQueue.Create(messageQueue.Path);
                }
                messageQueue.Formatter = new XmlMessageFormatter(new Type[] { typeof(string) });
                messageQueue.ReceiveCompleted += MessageQueue_ReceiveCompleted; 
                messageQueue.Send(token);
                messageQueue.BeginReceive();
                messageQueue.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void MessageQueue_ReceiveCompleted(object sender, ReceiveCompletedEventArgs e)
        {
            var message = messageQueue.EndReceive(e.AsyncResult);
            string token = message.Body.ToString();
            try
            {
                MailMessage mailMessage = new MailMessage();
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    EnableSsl = true,
                    Credentials = new NetworkCredential("pratik987ingole@gmail.com", "Pratik@987")
                };
                mailMessage.From = new MailAddress("pratik987ingole@gmail.com");
                mailMessage.To.Add(new MailAddress("pratik987ingole@gmail.com"));
                mailMessage.Body = token;
                mailMessage.Subject = "Forgot Password";
                smtpClient.Send(mailMessage);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
