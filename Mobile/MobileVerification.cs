using Abp.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Clients;
using Twilio.Http;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Rest.Chat.V2;
using Twilio.Rest.Verify.V2.Service;

namespace MoneyOnTime.Mobile
{
    public class MobileVerification : ISmsSender
    {
        private readonly string TwilioAccountIdentification;
        private readonly string TwilioAccountPassword;
        private readonly string TwilioAccountFrom;

        public MobileVerification(SettingManager settingManager)
        {
            TwilioAccountIdentification = settingManager.GetSettingValue("SMSAccountIdentification");
            TwilioAccountPassword = settingManager.GetSettingValue("SMSAccountPassword");
            TwilioAccountFrom = settingManager.GetSettingValue("SMSAccountFrom");
        }

        public async Task createVerificationService()
        {
            TwilioClient.Init(TwilioAccountIdentification, TwilioAccountPassword);

            var service = await ServiceResource.CreateAsync(
                    new CreateServiceOptions("My verification"));
        }
        public async Task SendAsync(SmsMessage smsMessage)
        {
            TwilioClient.Init(TwilioAccountIdentification, TwilioAccountPassword);

            await createVerificationService();
            
            var verification = await VerificationResource.CreateAsync(
                                new CreateVerificationOptions("My verification", "+150017122661", VerificationResource.ChannelEnum.Sms.ToString()));
             
            Console.WriteLine(verification.Valid);
            Console.WriteLine(verification.Status);
        }
        public async Task verificationCheck (string otp)
        {
            TwilioClient.Init(TwilioAccountIdentification, TwilioAccountPassword);
            var verificationCheck  =await VerificationCheckResource
                                        .CreateAsync(new CreateVerificationCheckOptions("My verification", otp));
            Console.WriteLine(verificationCheck.Status);
        }
    }
}
