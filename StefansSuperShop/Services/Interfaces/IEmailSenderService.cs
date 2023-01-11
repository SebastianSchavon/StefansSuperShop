namespace StefansSuperShop.Services.EmailSender;

public interface IEmailSenderService
{
    void SendEmail(string fromName, string header, string message, string reciever);
}