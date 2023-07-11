using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CourseReportEmailer.Workers
{
    public class EnrollmentDetailReportEmailSender
    {
        public void Send(string fileName)
        {
            SmtpClient client = new SmtpClient("smtp-mail.outlook.com");
            client.Port = 587;
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            
            NetworkCredential creds = new NetworkCredential("youremail@outlook.com", "password");

            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Credentials = creds;
            
            MailMessage message = new MailMessage("youremail@outlook.com", "to@outlook.com");
            message.Subject = "Enrollment Details Report";
            message.IsBodyHtml = true;
            message.Body = "Hi, <br><br>Attached please find the enrollment detail report." +
                           "<br><br>Please let me know if there are any questions." +
                           "<br><br>Best,<br><br>HeavySmile";
            message.Attachments.Add(new Attachment(fileName));
            client.Send(message);
        }
    }
}
