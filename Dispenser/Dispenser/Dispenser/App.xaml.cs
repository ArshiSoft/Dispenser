using Dispenser.Class;
using Dispenser.Views;
using Dispenser.Views.Forms;
using Xamarin.Forms;

namespace Dispenser
{
    public partial class App : Application
    {

        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NTAyMzE4QDMxMzkyZTMyMmUzMERsK3FaMmtGVEIvempSZVhGVndHQ3FJYmlpTnpXMDFsUHYwL3NHdzI3Rkk9");
            InitializeComponent();
            MainPage = new LoginPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
