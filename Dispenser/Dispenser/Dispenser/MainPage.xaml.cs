using Dispenser.Class;
using Dispenser.Models;
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

        protected override void OnAppearing()
        {
            base.OnAppearing();

            view.RefreshCommand.Execute(null);
        }

        async void Sedimental_Tapped(System.Object sender, System.EventArgs e)
        {
            if (view.IsEditable)
            {
                var rtnValue = await Application.Current.MainPage.DisplayAlert("Filter Reset", "Are you sure to reset?", "Yes", "No");

                if (rtnValue)
                {
                    var model = new ResetFilter
                    {
                        DeviceID = 1,
                        IsSedimental = true
                    };

                    try
                    {
                        clsGvar.StartWaiting();
                        var result = await clsGvar.MyAPI.ResetFilter(model);
                        await clsGvar.PopUpCurrent();

                        if (!result)
                        {
                            clsGvar.ShowMessege(PopupType.Warning, 3, "Something went wrong!");
                            return;
                        }

                        view.SedimentalFilter = 0;
                        clsGvar.ShowMessege(PopupType.Success, 3, "Filter reset successfully!");
                    }
                    catch
                    {
                        await clsGvar.PopUpCurrent();
                        clsGvar.ShowMessege(PopupType.Error, 3, "Connection Problem!");
                    }
                }
            }
        }

        async void GAC_Tapped(System.Object sender, System.EventArgs e)
        {
            if (view.IsEditable)
            {
                var rtnValue = await Application.Current.MainPage.DisplayAlert("Filter Reset", "Are you sure to reset?", "Yes", "No");

                if (rtnValue)
                {
                    var model = new ResetFilter
                    {
                        DeviceID = 1,
                        IsGAC = true
                    };

                    try
                    {
                        clsGvar.StartWaiting();
                        var result = await clsGvar.MyAPI.ResetFilter(model);
                        await clsGvar.PopUpCurrent();

                        if (!result)
                        {
                            clsGvar.ShowMessege(PopupType.Warning, 3, "Something went wrong!");
                            return;
                        }

                        view.GACFilter = 0;
                        clsGvar.ShowMessege(PopupType.Success, 3, "Filter reset successfully!");
                    }
                    catch
                    {
                        await clsGvar.PopUpCurrent();
                        clsGvar.ShowMessege(PopupType.Error, 3, "Connection Problem!");
                    }
                }
            }
        }

        async void Carbon_Tapped(System.Object sender, System.EventArgs e)
        {
            if (view.IsEditable)
            {
                var rtnValue = await Application.Current.MainPage.DisplayAlert("Filter Reset", "Are you sure to reset?", "Yes", "No");

                if (rtnValue)
                {
                    var model = new ResetFilter
                    {
                        DeviceID = 1,
                        IsCarbon = true
                    };

                    try
                    {
                        clsGvar.StartWaiting();
                        var result = await clsGvar.MyAPI.ResetFilter(model);
                        await clsGvar.PopUpCurrent();

                        if (!result)
                        {
                            clsGvar.ShowMessege(PopupType.Warning, 3, "Something went wrong!");
                            return;
                        }

                        view.CarbonFilter = 0;
                        clsGvar.ShowMessege(PopupType.Success, 3, "Filter reset successfully!");
                    }
                    catch
                    {
                        await clsGvar.PopUpCurrent();
                        clsGvar.ShowMessege(PopupType.Error, 3, "Connection Problem!");
                    }
                }
            }
        }

        async void RO_Tapped(System.Object sender, System.EventArgs e)
        {
            if (view.IsEditable)
            {
                var rtnValue = await Application.Current.MainPage.DisplayAlert("Filter Reset", "Are you sure to reset?", "Yes", "No");

                if (rtnValue)
                {
                    var model = new ResetFilter
                    {
                        DeviceID = 1,
                        IsRO = true
                    };

                    try
                    {
                        clsGvar.StartWaiting();
                        var result = await clsGvar.MyAPI.ResetFilter(model);
                        await clsGvar.PopUpCurrent();

                        if (!result)
                        {
                            clsGvar.ShowMessege(PopupType.Warning, 3, "Something went wrong!");
                            return;
                        }

                        view.ROFilter = 0;
                        clsGvar.ShowMessege(PopupType.Success, 3, "Filter reset successfully!");
                    }
                    catch
                    {
                        await clsGvar.PopUpCurrent();
                        clsGvar.ShowMessege(PopupType.Error, 3, "Connection Problem!");
                    }
                }
            }
        }

        async void PostCarbon_Tapped(System.Object sender, System.EventArgs e)
        {
            if (view.IsEditable)
            {
                var rtnValue = await Application.Current.MainPage.DisplayAlert("Filter Reset", "Are you sure to reset?", "Yes", "No");

                if (rtnValue)
                {
                    var model = new ResetFilter
                    {
                        DeviceID = 1,
                        IsPostCarbon = true
                    };

                    try
                    {
                        clsGvar.StartWaiting();
                        var result = await clsGvar.MyAPI.ResetFilter(model);
                        await clsGvar.PopUpCurrent();

                        if (!result)
                        {
                            clsGvar.ShowMessege(PopupType.Warning, 3, "Something went wrong!");
                            return;
                        }

                        view.PostCarbonFilter = 0;
                        clsGvar.ShowMessege(PopupType.Success, 3, "Filter reset successfully!");
                    }
                    catch
                    {
                        await clsGvar.PopUpCurrent();
                        clsGvar.ShowMessege(PopupType.Error, 3, "Connection Problem!");
                    }
                }
            }
        }

        async void Remineralization_Tapped(System.Object sender, System.EventArgs e)
        {
            if (view.IsEditable)
            {
                var rtnValue = await Application.Current.MainPage.DisplayAlert("Filter Reset", "Are you sure to reset?", "Yes", "No");

                if (rtnValue)
                {
                    var model = new ResetFilter
                    {
                        DeviceID = 1,
                        IsRemineralization = true
                    };

                    try
                    {
                        clsGvar.StartWaiting();
                        var result = await clsGvar.MyAPI.ResetFilter(model);
                        await clsGvar.PopUpCurrent();

                        if (!result)
                        {
                            clsGvar.ShowMessege(PopupType.Warning, 3, "Something went wrong!");
                            return;
                        }

                        view.RemineralizationFilter = 0;
                        clsGvar.ShowMessege(PopupType.Success, 3, "Filter reset successfully!");
                    }
                    catch
                    {
                        await clsGvar.PopUpCurrent();
                        clsGvar.ShowMessege(PopupType.Error, 3, "Connection Problem!");
                    }
                }
            }
        }
    }
}
