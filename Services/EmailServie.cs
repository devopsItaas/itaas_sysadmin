using MailKit.Net.Smtp;
using MimeKit;
using Microsoft.Extensions.Configuration;

/// <summary>
/// Servicio para enviar correos electrónicos utilizando la configuración SMTP definida en appsettings.json.
/// </summary>
public class EmailService
{
    private readonly IConfiguration _config;

    /// <summary>
    /// Constructor que recibe la configuración de la aplicación.
    /// </summary>
    /// <param name="config">Interfaz de configuración para acceder a appsettings.json</param>
    public EmailService(IConfiguration config)
    {
        _config = config;
    }

    /// <summary>
    /// Envía un correo electrónico de forma asíncrona.
    /// </summary>
    /// <param name="to">Correo electrónico del destinatario</param>
    /// <param name="subject">Asunto del correo</param>
    /// <param name="body">Cuerpo del mensaje (puede ser HTML)</param>
    public async Task SendEmailAsync(string to, string subject, string body)
    {
        // Crear el mensaje de correo
        var email = new MimeMessage();
        email.From.Add(MailboxAddress.Parse(_config["Smtp:From"]));
        email.To.Add(MailboxAddress.Parse(to));
        email.Subject = subject;
        email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = body };

        // Conectarse al servidor SMTP y enviar el correo
        using var smtp = new SmtpClient();
        await smtp.ConnectAsync(_config["Smtp:Host"], int.Parse(_config["Smtp:Port"]), false);
        await smtp.AuthenticateAsync(_config["Smtp:User"], _config["Smtp:Password"]);
        await smtp.SendAsync(email);
        await smtp.DisconnectAsync(true);
    }
}