using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyOnTime.Mobile
{
    public class SmsMessage
    {
        public SmsMessage(string phoneNumber, string text)
        {
            PhoneNumber = phoneNumber;
            Text = text;
        }

        public string PhoneNumber { get; }
        public string Text { get; }
        public IDictionary<string,object> Properties { get; }
    }
}
