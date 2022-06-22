# emailmobieverificationpart
To integrate it with MoneyOnTime project , put **Email** and **Mobile** folder in **MoneyOnTime.Core module,**
and add line 
       **Configuration**.**Settings**.**Providers**.**Add**<**AmazonSESSettingProvider**>();
       **Configuration**.**Settings**.**Providers**.**Add**<**MobileSettingProvider**>();
to **MoneyOnTimeCoreModule.cs** file in **PreInitialize method** present in **MoneyOnTime.Core** Module.
