using Application.Interfaces.IEmail;
using MailKit.Net.Smtp;
using MimeKit;

namespace Application.UseCases;

public class EmailService : IEmailService
{
    public async Task SendEmailAsync(string toEmail, string subject, string message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("Solicitud", "puppytech07@gmail.com"));
            emailMessage.To.Add(new MailboxAddress("", toEmail));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart("plain") { Text = message };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                await client.AuthenticateAsync("puppytech07@gmail.com", "obty dtnz yzdm dstb");
                await client.SendAsync(emailMessage);
                await client.DisconnectAsync(true);
            }
        }
}
