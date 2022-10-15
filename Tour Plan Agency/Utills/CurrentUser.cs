using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mail;
using Tour_Plan_Agency.Models;


namespace Tour_Plan_Agency.Utills
{
    public static class CurrentUser
    {
        public  static tblCustomer  CurrentCustomer { get; set; }
    }
    public static class EmailProvider
    {
        
        public  static bool SendEmail(string receiver,string subject,string EmailBody)
        {
            try
            {
                var message = new System.Net.Mail.MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress("nazishiftikhar112@gmail.com");
                message.To.Add(new MailAddress(receiver));
                message.Subject = "Test";
                message.IsBodyHtml = true; //to make message body as html  
                message.Body = EmailBody;
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com"; //for gmail host  
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("nazishiftikhar112@gmail.com", "Irjgytcntwstosth");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
            }
            catch (Exception) { return false; }
            return true;
        }
    }
}