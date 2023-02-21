using DevPortfolio.Models;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Text;

namespace DevPortfolio.Services
{
    public class MailSendingService
    {
        private SendGridClient _client;
        private string _fromEmail;
        private string _fromName;
        private string _toAddress;

        public MailSendingService(string sendGridApiKey, string fromEmail, string fromName, string toAddress)
        {
            _client = new SendGridClient(sendGridApiKey);
            _fromEmail = fromEmail;
            _fromName = fromName;
            _toAddress = toAddress;
        }

        public async void Send(ContactFormModel model)
        {
            var from = new EmailAddress(_fromEmail, _fromName);
            var subject = "New message from your Portfolio website";
            var to = new EmailAddress(_toAddress, "Website Owner");

            StringBuilder content = new StringBuilder();
            content.AppendLine("New message from your website");
            content.AppendLine($"Name: {model.Name}");
            content.AppendLine($"Email: {model.Email}");
            content.AppendLine($"Phone: {model.Phone}");
            content.AppendLine($"Message: {model.Message}");

            var plainTextContent = content.ToString();

            content.Clear();

            content.AppendLine("<h1>New message from your website</h1>");
            content.AppendLine($"<p><strong>Name:</strong> {model.Name}</p>");
            content.AppendLine($"<p><strong>Email:</strong> {model.Email}</p>");
            content.AppendLine($"<p><strong>Phone:</strong> {model.Phone}</p>");
            content.AppendLine($"<p><strong>Message:</strong> {model.Message}</p>");

            var htmlContent = content.ToString();
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var result =  await _client.SendEmailAsync(msg);
            Console.WriteLine(result);
        }
    }
}