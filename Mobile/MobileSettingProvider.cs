using Abp.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyOnTime.Mobile
{
    public class MobileSettingProvider : SettingProvider
    {
        public override IEnumerable<SettingDefinition> GetSettingDefinitions(SettingDefinitionProviderContext context)
        {
            return new[]
           {
                new SettingDefinition(
                    "SMSAccountIdentification",
                    "AKIAUFDATCJNWVKWBDW5"
                    ),

                new SettingDefinition(
                    "SMSAccountPassword",
                    "b6OoVi92ZGqfpe2K7dUrlRf6BruDtV90hz+eSxCZ"),

               new SettingDefinition(
                    "SMSAccountFrom",
                    "b6OoVi92ZGqfpe2K7dUrlRf6BruDtV90hz+eSxCZ")
            };
        }
    }
}
