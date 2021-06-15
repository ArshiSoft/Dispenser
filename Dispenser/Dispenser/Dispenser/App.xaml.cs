using Xamarin.Forms;

namespace Dispenser
{
    public partial class App : Application
    {

        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NDM5Mzk2QDMxMzkyZTMxMmUzMENkWjJSdFVLTUFqSmozdklpWnJoSUhsWGZkTkpKTndwM09IbEtuUHF1S009");
            InitializeComponent();
            MainPage = new MainPage();
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
