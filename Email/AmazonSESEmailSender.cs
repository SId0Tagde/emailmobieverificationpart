using Abp.Configuration;
using Abp.Domain.Services;
using Abp.Net.Mail;
using Amazon;
using Amazon.SimpleEmailV2;
using Amazon.SimpleEmailV2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MoneyOnTime.Email
{
    public class AmazonSESEmailSender :  DomainService , IEmailSender
    {
        private readonly string awsAccessKey;
        private readonly string awsSecretKey;
        public AmazonSESEmailSender(SettingManager settingManager)
        {
            awsAccessKey = settingManager.GetSettingValue("awsAccessKey");
            awsSecretKey = settingManager.GetSettingValue("awsSecretKey");
        }
        public void Send(string from, string to, string subject, string body, bool isBodyHtml = true)
        {
            throw new NotImplementedException();
        }
        public void Send(string to, string subject, string body, bool isBodyHtml = true)
        {
            throw new NotImplementedException();
        }
        public void Send(MailMessage mail, bool normalize = true)
        {
            throw new NotImplementedException();
        }
        public CreateEmailTemplateRequest createVerificationTemplate(string body)
        {
            var template = new CreateEmailTemplateRequest
            {
                TemplateName ="Verification template",
                TemplateContent = new EmailTemplateContent
                {
                    Subject = "Verification",
                    Html = body,
                    Text = "your email client does not display html."
                }
            };
            return template;
        }
        public async Task SendAsync(string to, string subject, string body, bool isBodyHtml = true)
        {
            var verificationtemplate = createVerificationTemplate(body);
            var sendRequest = new SendEmailRequest
            {
                FromEmailAddress = "noreply@notification.moneyontime.ai",
                Destination = new Destination
                {
                    ToAddresses = new List<string> { to }
                },
                Content = new EmailContent
                {                    
                    Simple = new Message
                    {
                        Subject = new Content
                        {
                            Charset = "UTF-8",
                            Data = subject
                        },
                        Body = new Body
                        {
                            Html = new Content
                            {
                                Charset = "UTF-8",
                                Data = body
                            },
                            Text = new Content
                            {
                                Charset = "UTF-8",
                                Data = "Content not supported"
                            }
                        }
                    }
                },
            };
            using (AmazonSimpleEmailServiceV2Client amazonSES = new(awsAccessKeyId: awsAccessKey,
                                awsSecretAccessKey: awsSecretKey, RegionEndpoint.USWest2))
            {
                var response = await amazonSES.SendEmailAsync(sendRequest);
                Console.WriteLine(response.HttpStatusCode);
            }
        }

        //Send Async
        public async Task SendAsync(MailMessage mail, bool normalize = true)
        {
            var sendRequest = new SendEmailRequest
            {
                FromEmailAddress = mail.From.ToString(),
                Destination = new Destination
                {
                    ToAddresses = new List<string> { mail.To.ToString() }
                },
                Content = new EmailContent
                {
                    Simple = new Message
                    {
                        Subject = new Content
                        {
                            Charset = "UTF-8",
                            Data = mail.Subject
                        },
                        Body = new Body
                        {
                            Html = new Content
                            {
                                Charset = "UTF-8",
                                Data = mail.Body
                            },
                            Text = new Content
                            {
                                Charset = "UTF-8",
                                Data = "Content not supported"
                            }
                        }
                    }
                },
            };
            using (AmazonSimpleEmailServiceV2Client amazonSES = new(awsAccessKeyId: awsAccessKey,
                                awsSecretAccessKey: awsSecretKey, RegionEndpoint.USWest2))
            {
                var response = await amazonSES.SendEmailAsync(sendRequest);
                Console.WriteLine(response.HttpStatusCode);
            }
        }
        
        //Send Async
        public async Task SendAsync(string from, string to, string subject, string body, bool isBodyHtml = true)
        {
            var sendRequest = new SendEmailRequest
            {
                //FromEmailAddress = "noreply@notification.moneyontime.ai",
                FromEmailAddress = from,
                Destination = new Destination
                {
                    //ToAddresses = new List<string> { "bhulbhula@notification.moneyontime.ai" }
                    ToAddresses = new List<string> { to }
                },
                Content = new EmailContent
                {
                    Simple = new Message
                    {
                        Subject = new Content
                        {
                            Charset = "UTF-8",
                            Data = subject
                        },
                        Body = new Body
                        {
                            Html = new Content
                            {
                                Charset = "UTF-8",
                                Data = "This email was delivered through the Amazon SES API."
                            },
                            Text = new Content
                            {
                                Charset = "UTF-8",
                                Data = "Content not supported"
                            }
                        }
                    }
                },
            };
            using (AmazonSimpleEmailServiceV2Client amazonSES = new(awsAccessKeyId: awsAccessKey,
                                awsSecretAccessKey: awsSecretKey, RegionEndpoint.USWest2))
            {
                var response = await amazonSES.SendEmailAsync(sendRequest);
                Console.WriteLine(response.HttpStatusCode);
            }
        }
    }
}