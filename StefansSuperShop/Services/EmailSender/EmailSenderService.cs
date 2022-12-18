using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using StefansSuperShop.Models.Options;
using MailKit.Net.Smtp;

namespace StefansSuperShop.Services.EmailSender;

public class EmailSenderService : IEmailSenderService
{
    private readonly MailSettings _settings;

    public EmailSenderService(IOptions<MailSettings> mailSettings)
    {
        _settings = mailSettings.Value;
    }

    public void SendEmail(string fromName, string header, string message)
    {
        var mail = new MimeMessage();

        // // Sender
        // mail.From.Add(new MailboxAddress(_settings.DisplayName, _settings.From));
        mail.Sender = new MailboxAddress(_settings.DisplayName, _settings.From);

        // Receiver
        mail.To.Add(MailboxAddress.Parse("billgates@microsoft.com"));
        
        // Add Content to Mime Message
        var body = new BodyBuilder();
        mail.Subject = header;
        body.HtmlBody = message;
        mail.Body = body.ToMessageBody();
        
        using var smtp = new SmtpClient();
        
        smtp.ConnectAsync(_settings.Host, _settings.Port, SecureSocketOptions.StartTls).Wait();

        smtp.AuthenticateAsync(_settings.UserName, _settings.Password).Wait();
        smtp.SendAsync(mail).Wait();
        smtp.DisconnectAsync(true).Wait();
    }
}