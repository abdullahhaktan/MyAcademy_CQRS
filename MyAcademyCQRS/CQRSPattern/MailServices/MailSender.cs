using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace MyAcademyCQRS.CQRSPattern.MailServices
{
    public class MailSender : IMailSender
    {
        private readonly string _smtpHost;
        private readonly int _smtpPort;
        private readonly string _smtpUserName;
        private readonly string _smtpPassword;

        public MailSender(IConfiguration configuration)
        {
            _smtpHost = configuration["Mail:SmtpHost"];
            _smtpPort = int.Parse(configuration["Mail:SmtpPort"]);
            _smtpUserName = configuration["Mail:SmtpUserName"];
            _smtpPassword = configuration["Mail:SmtpPassword"];
        }

        public async Task SendAsync(string toEmail, string subject, string body)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("MyAcademy", _smtpUserName));
            message.To.Add(MailboxAddress.Parse(toEmail));
            message.Subject = subject;

            message.Body = new TextPart("plain")
            {
                Text = body
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(_smtpHost, _smtpPort, SecureSocketOptions.StartTls);
                await client.AuthenticateAsync(_smtpUserName, _smtpPassword);
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }

        }
    }
}
