using MedicalChecker.Utility.Helper;
using Microsoft.AspNetCore.Identity.UI.Services;
using MimeKit;
using System.Net.Mail;

namespace MedicalChecker.Services.Implementation
{
    public class EmailSender : IEmailSender
    {
        #region Fields
        private readonly EmailSettings _emailSettings;
        #endregion

        #region Constructor
        public EmailSender(EmailSettings emailSettings)
        {
            _emailSettings = emailSettings;
        }
        #endregion
        #region Handel Functions
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {

            try
            {
                using (var client = new MailKit.Net.Smtp.SmtpClient())
                {
                    await client.ConnectAsync(_emailSettings.Host, _emailSettings.Port);
                    client.Authenticate(_emailSettings.Email, _emailSettings.Password);
                    var bodyBuilder = new BodyBuilder()
                    {
                        HtmlBody = htmlMessage,
                    };
                    var message = new MimeMessage()
                    {
                        Body = bodyBuilder.ToMessageBody()
                    };
                    message.From.Add(new MailboxAddress("Medical Checker Team", _emailSettings.Email));
                    message.To.Add(new MailboxAddress("User", email));
                    message.Subject = subject;

                    await client.SendAsync(message);
                    await client.DisconnectAsync(true);
                }
            }
            catch (SmtpFailedRecipientException ex)
            {
                throw new Exception("Failed to deliver email to one or more recipients.", ex);
            }
            catch (SmtpException ex)
            {
                throw new Exception("An error occurred while sending the email.", ex);
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception("Email, subject, or message cannot be null.", ex);
            }
            catch (InvalidOperationException ex)
            {
                throw new Exception("An invalid operation occurred while sending the email.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred while sending the email.", ex);
            }
        }
        #endregion
    }
}
