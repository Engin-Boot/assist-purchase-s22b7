using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Net.Mail;
using DatabaseContractor;

namespace AssistPurchase.Repositories
{
    public interface IAlerter
    {
        void Alert(SalesInput message);
    }
    [ExcludeFromCodeCoverage]
    public class EmailAlert : IAlerter
    {
        public void Alert(SalesInput salesInput)
        {
            string message = $"hi, \n Please try to reach the below customer at the earliest.\nCustomer Name : {salesInput.CustomerName} \nEmail Id : {salesInput.EmailId} \n Products of Interest: ";
            for (int i = 0; i < salesInput.Description.Length; i++) {
                message += $"\n{i+1}.{salesInput.Description[i].Name}";
            }
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("atuljha2524@gmail.com", "atuljha910"),
                EnableSsl = true,
            };
            smtpClient.Send("atuljha2524@gmail.com", "atuljha910@gmail.com", "ALERT", message);
            
        }
    }
}
