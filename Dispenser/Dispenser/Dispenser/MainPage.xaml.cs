using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Dispenser
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            view.Navigation = Navigation;
        }
    }
}
