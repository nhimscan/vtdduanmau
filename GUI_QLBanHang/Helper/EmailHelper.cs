using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GUI_QLBanHang.Helper
{
    public static class EmailHelper
    {
        public static string SendMail(string toEmail, string subject, string message)
        {
            var fromAddress = new MailAddress("noreply@chuyenweb.net", "ChuyenWeb.net");
            const string fromPassword = "husdsdsodfdfdngfdf@8";
            var toAddress = new MailAddress(toEmail, toEmail);
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var emailMessage = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = message
            })
                try
                {
                    smtp.Send(emailMessage);
                    return "";
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
        }
        public static bool IsValidEmail(string email)
        {
            var trimmedEmail = email.Trim();
            if (trimmedEmail.EndsWith(".")) {
                return false;
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }

    }
}
