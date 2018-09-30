using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;

namespace UpstackTest
{
    public class EMailSender
    {
        // To move to config or resources
        private const string VERIFICATION_MAIL = "zonamailbox@gmail.com";
        private const string VERIFICATION_MAIL_PASS = "Bb123456!";

        private const string SUBJECT = "Upstack Test Activation Email";
        private const string MESSAGE = "To activate your account please enter: ";

        // This of course it temporary until site is actually hosted.
        private const string ACTIVATE_URL = "http://localhost:52362/api/Users/Activate/";

        public void SendActivationEMail(string targetEmail, int id)
        {
            try
            {
                using (var mailMessage = new MailMessage(VERIFICATION_MAIL, targetEmail))
                using (var smtpServer = new SmtpClient("smtp.gmail.com"))
                {
                    mailMessage.Subject = SUBJECT;
                    mailMessage.Body = FormMessage(id);

                    smtpServer.Port = 587;
                    smtpServer.Credentials = new System.Net.NetworkCredential("zonamailbox", VERIFICATION_MAIL_PASS);
                    smtpServer.EnableSsl = true;

                    smtpServer.Send(mailMessage);
                }
            }
            catch (Exception ex)
            {
                // At least info to log should be added.
            }
        }

        private string FormMessage(int id)
        {
            return MESSAGE + ACTIVATE_URL + id;
        }
    }
}