using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDoListUniversity
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]

        
        static void Main()
        {
            //Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mgo+DSMBaFt/QHJqVVhjWlpFdEBBXHxAd1p/VWJYdVt5flBPcDwsT3RfQF9jTnxSdkdnX3tZeXxQQg==;Mgo+DSMBPh8sVXJ0S0R+XE9HcFRDX3xKf0x/TGpQb19xflBPallYVBYiSV9jS3xTcUdiWX1adnBST2lUVQ==;ORg4AjUWIQA/Gnt2VVhiQlFadVlJXGFWfVJpTGpQdk5xdV9DaVZUTWY/P1ZhSXxRdkJhWH9cdHJRTmBcWUA=;NjgxMTExQDMyMzAyZTMyMmUzMGl1Z0FxY3NUblRmM0V1MVV6dTExODRDeEpTcVExVk93dU1tL2RreStVY3M9;NjgxMTEyQDMyMzAyZTMyMmUzMFkvS3djZFRucWZCV3ZIQkpHM2dkTm12WG9vOVBjb1FUbXRlNFJyclFDSzg9;NRAiBiAaIQQuGjN/V0Z+Xk9EaFxEVmJLYVB3WmpQdldgdVRMZVVbQX9PIiBoS35RdEVkW35ecnBTQmhcVkdy;NjgxMTE0QDMyMzAyZTMyMmUzMFpGcHQveVNkQmVTeEp3VWdIOWJiY0srMzNZQ1J1MVVWWGNUanpMM1lwNjg9;NjgxMTE1QDMyMzAyZTMyMmUzME9tUmFKSEhjL3hZUTY4aEU4U0ZDRDVIVHpaSTIxOHhHV1Q1YkxCMHBieW89;Mgo+DSMBMAY9C3t2VVhiQlFadVlJXGFWfVJpTGpQdk5xdV9DaVZUTWY/P1ZhSXxRdkJhWH9cdHJRTmFfVEA=;NjgxMTE3QDMyMzAyZTMyMmUzMFlkcGhnNDJ6a01tL0laRUlBQUFFa2dBYm54NFFvMERKZW9aQ0Z5a0ZScGM9;NjgxMTE4QDMyMzAyZTMyMmUzMENqYUNGcVp5SFhRY25JaFRjZnRoaGxLZ09tVk5TamJmbHFuMndwYmFGWG89;NjgxMTE5QDMyMzAyZTMyMmUzMFpGcHQveVNkQmVTeEp3VWdIOWJiY0srMzNZQ1J1MVVWWGNUanpMM1lwNjg9");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            Application.Run(new LoginForm());
        }
    }
}
