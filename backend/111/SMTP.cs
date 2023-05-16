using System.Net;
using System.Net.Mail;
using System.Reflection;

namespace _111
{
    public class SMTP
    {
        const string login = "practic@xenix19.ru";
        const string password = "FmXGyJjmQ5cR9s434ahc";
        const string host = "smtp.mail.ru";
        const int port = 2525;

        SmtpClient client = new SmtpClient();

        public SMTP()
        {
            client.Port = port;
            client.Host = host;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(login, password);
            client.EnableSsl = true;
        }

        public bool SendVerificationCode(string email, int code)
        {
            try
            {
                MailAddress from = new MailAddress(login, "Учебная практика - Ремнев П. ХПК");
                MailAddress to = new MailAddress(email);
                MailMessage myMail = new System.Net.Mail.MailMessage(from, to);


                string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"EmailHtml\Verification.html");
                string template = new StreamReader(path).ReadToEnd();

                myMail.Subject = "CoalDelivery - Подтверждение почты";
                myMail.SubjectEncoding = System.Text.Encoding.UTF8;



                myMail.Body = template.Replace("%code", code.ToString());
                myMail.BodyEncoding = System.Text.Encoding.UTF8;
                myMail.IsBodyHtml = true;

                client.Send(myMail);
                return true;
            }

            catch (SmtpException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false; 
            }
        }
    }
}