using Airline.Application.Services.Interfaces;
using Airline.Infrastructure.Configurations;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;

namespace Airline.Infrastructure.Email;

public class EmailService : IEmailService
{
    private readonly EmailOptions _options;

    public EmailService(IOptionsMonitor<EmailOptions> options)
    {
        _options = options.CurrentValue;
    }

    public void SendEmail(List<MailboxAddress> to, string subject, string content)
    {

        var emailMessage = CreateEmailMessage(to, subject, content);

        Send(emailMessage);
    }

    private MimeMessage CreateEmailMessage(List<MailboxAddress> to, string subject, string content)
    {
        var emailMessage = new MimeMessage();
        emailMessage.From.Add(new MailboxAddress("Airlines", _options.From));
        emailMessage.To.AddRange(to);
        emailMessage.Subject = subject;
        emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = content };

        return emailMessage;
    }

    private void Send(MimeMessage mailMessage)
    {
        using var client = new SmtpClient();

        try
        {
            client.Connect(_options.SmtpServer, _options.Port, true);
            client.AuthenticationMechanisms.Remove("XOAUTH2");
            client.Authenticate(_options.Username, _options.Password);
            client.Send(mailMessage);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            client.Disconnect(true);
        }
    }
}
