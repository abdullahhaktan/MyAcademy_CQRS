namespace MyAcademyCQRS.CQRSPattern.MailServices
{
    public interface IMailSender
    {
        public Task SendAsync(string toEmail, string subject, string body);
    }
}
