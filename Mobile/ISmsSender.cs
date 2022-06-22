using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyOnTime.Mobile
{
    public interface ISmsSender
    {
        Task SendAsync(SmsMessage smsMessage);

        Task verificationCheck(string otp);
    }
}
