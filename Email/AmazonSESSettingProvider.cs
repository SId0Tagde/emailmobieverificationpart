using Abp.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyOnTime.Email
{
    public class AmazonSESSettingProvider : SettingProvider
    {
        public override IEnumerable<SettingDefinition> GetSettingDefinitions(SettingDefinitionProviderContext context)
        {
            return new[]
            {
                new SettingDefinition(
                    "awsAccessKey",
                    "AKIAUFDATCJNWVKWBDW5"
                    ),

                new SettingDefinition(
                    "awsSecretKey",
                    "b6OoVi92ZGqfpe2K7dUrlRf6BruDtV90hz+eSxCZ")
            };
        }
    }
}
