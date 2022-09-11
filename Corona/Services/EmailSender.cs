using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Corona.Services
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            return Task.Run(() => { SendEmail(email, subject, message); });
        }

        /*
         *    return emailSender.SendEmailAsync(email, "Confirm your email",
                $"Please confirm your account by clicking this link: <a href='{HtmlEncoder.Default.Encode(link)}'>link</a>");
         */

        public bool SendEmail(string email, string subject, string message)
        {
            try
            {
                MailMessage msz = new MailMessage
                {
                    From = new MailAddress("zmzingeli@gmail.com"),//Email which you are getting from contact us page 
                    Subject = subject,
                    Body = message,
                    IsBodyHtml = false
                };
                msz.To.Add(email);//Where mail will be sent  
                SmtpClient smtp = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    UseDefaultCredentials = true,
                    EnableSsl = true,
                    Credentials = new System.Net.NetworkCredential("zmzingeli@gmail.com", "22029212"),
                };

                smtp.Send(msz);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
