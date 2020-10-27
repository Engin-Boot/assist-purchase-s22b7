
using DatabaseContractor;
using System.Net;
using System.Net.Mail;

namespace Alert_to_Care.Repository
{
    public interface Alerter
    {
        bool Alert(SalesInput message);
    }
    public class EmailAlert : Alerter
    {
        public bool Alert(SalesInput salesInput)
        {
            string message = $"hi, {salesInput.CustomerName} with {salesInput.EmailId} email-id is intrested in following products {salesInput.Description}";
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("atuljha2524@gmail.com", "atuljha910"),
                EnableSsl = true,
            };
            smtpClient.Send("atuljha2524@gmail.com", "atuljha910@gmail.com", "ALERT", message);
            return true;
        }
    }
}
