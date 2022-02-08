using Dispenser.Class;
using Dispenser.Views.Forms;
using Syncfusion.XForms.Buttons;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace Dispenser.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        DateTime date;
        bool isrefreshing;
        bool iseditable;
        int flowsensor1;
        int tdssensor1;
        int tdssensor2;
        int tdssensor1max;
        int tdssensor2max;
        int coldtemp;
        int hottemp;
        int selectedtemp;
        int uvled;
        int sedimentalfilter;
        int gacfilter;
        int carbonfilter;
        int rofilter;
        int postcarbonfilter;
        int remineralizationfilter;
        int sedimentalfiltermax;
        int gacfiltermax;
        int carbonfiltermax;
        int rofiltermax;
        int postcarbonfiltermax;
        int remineralizationfiltermax;
        public MainViewModel()
        {
            Date = DateTime.Now;
            if (clsGvar.UserType == UserType.Employee)
                IsEditable = true;
            RefreshCommand = new Command(Refresh);
            SignOutCommand = new Command(SignOut);
        }
        public ObservableCollection<SfSegmentItem> Image_textCollection { get; set; }

        public ICommand RefreshCommand { get; }
        public ICommand SignOutCommand { get; }

        public DateTime Date
        {
            get { return date; }
            set { SetProperty(ref date, value); }
        }

        public int FlowSensor1
        {
            get { return flowsensor1; }
            set { SetProperty(ref flowsensor1, value); }
        }

        public bool IsRefreshing
        {
            get { return isrefreshing; }
            set { SetProperty(ref isrefreshing, value); }
        }

        public bool IsEditable
        {
            get { return iseditable; }
            set { SetProperty(ref iseditable, value); }
        }

        public int TDSSensor1
        {
            get { return tdssensor1; }
            set { SetProperty(ref tdssensor1, value); }
        }

        public int TDSSensor2
        {
            get { return tdssensor2; }
            set { SetProperty(ref tdssensor2, value); }
        }

        public int TDSSensor1Max
        {
            get { return tdssensor1max; }
            set { SetProperty(ref tdssensor1max, value); }
        }

        public int TDSSensor2Max
        {
            get { return tdssensor2max; }
            set { SetProperty(ref tdssensor2max, value); }
        }

        public int ColdTempSensor
        {
            get { return coldtemp; }
            set { SetProperty(ref coldtemp, value); }
        }

        public int HotTempSensor
        {
            get { return hottemp; }
            set { SetProperty(ref hottemp, value); }
        }

        public int SelectedTemp
        {
            get { return selectedtemp; }
            set { SetProperty(ref selectedtemp, value); }
        }

        public int UVLED
        {
            get { return uvled; }
            set { SetProperty(ref uvled, value); }
        }

        public int SedimentalFilter
        {
            get { return sedimentalfilter; }
            set { SetProperty(ref sedimentalfilter, value); }
        }

        public int GACFilter
        {
            get { return gacfilter; }
            set { SetProperty(ref gacfilter, value); }
        }

        public int CarbonFilter
        {
            get { return carbonfilter; }
            set { SetProperty(ref carbonfilter, value); }
        }

        public int ROFilter
        {
            get { return rofilter; }
            set { SetProperty(ref rofilter, value); }
        }

        public int PostCarbonFilter
        {
            get { return postcarbonfilter; }
            set { SetProperty(ref postcarbonfilter, value); }
        }

        public int RemineralizationFilter
        {
            get { return remineralizationfilter; }
            set { SetProperty(ref remineralizationfilter, value); }
        }

        public int SedimentalFilterMax
        {
            get { return sedimentalfiltermax; }
            set { SetProperty(ref sedimentalfiltermax, value); }
        }

        public int GACFilterMax
        {
            get { return gacfiltermax; }
            set { SetProperty(ref gacfiltermax, value); }
        }

        public int CarbonFilterMax
        {
            get { return carbonfiltermax; }
            set { SetProperty(ref carbonfiltermax, value); }
        }

        public int ROFilterMax
        {
            get { return rofiltermax; }
            set { SetProperty(ref rofiltermax, value); }
        }

        public int PostCarbonFilterMax
        {
            get { return postcarbonfiltermax; }
            set { SetProperty(ref postcarbonfiltermax, value); }
        }

        public int RemineralizationFilterMax
        {
            get { return remineralizationfiltermax; }
            set { SetProperty(ref remineralizationfiltermax, value); }
        }

        async void Refresh()
        {
            try
            {
                var deviceInfo = await clsGvar.MyAPI.GetDevice(1);

                FlowSensor1 = Convert.ToInt32(Math.Floor(deviceInfo.FlowSensor1.ToDecimal() / 1000.ToDecimal()));
                TDSSensor1 = deviceInfo.TDSSensor1;
                TDSSensor1Max = deviceInfo.TDSSensor1Max;
                TDSSensor2 = deviceInfo.TDSSensor2;
                TDSSensor2Max = deviceInfo.TDSSensor2Max;
                ColdTempSensor = deviceInfo.ColdTempSensor;
                HotTempSensor = deviceInfo.HotTempSensor;
                SedimentalFilter = Convert.ToInt32(Math.Floor(deviceInfo.SedimentalFilter.ToDecimal() / 1000.ToDecimal()));
                GACFilter = Convert.ToInt32(Math.Floor(deviceInfo.GACFilter.ToDecimal() / 1000.ToDecimal()));
                CarbonFilter = Convert.ToInt32(Math.Floor(deviceInfo.CarbonFilter.ToDecimal() / 1000.ToDecimal()));
                ROFilter = Convert.ToInt32(Math.Floor(deviceInfo.ROMembraneFilter.ToDecimal() / 1000.ToDecimal()));
                PostCarbonFilter = Convert.ToInt32(Math.Floor(deviceInfo.PostCarbonFilter.ToDecimal() / 1000.ToDecimal()));
                RemineralizationFilter = Convert.ToInt32(Math.Floor(deviceInfo.RemineralizationFilter.ToDecimal() / 1000.ToDecimal()));
                SedimentalFilterMax = deviceInfo.SedimentalFilterMax;
                GACFilterMax = deviceInfo.GACFilterMax;
                CarbonFilterMax = deviceInfo.CarbonFilterMax;
                ROFilterMax = deviceInfo.ROMembraneFilterMax;
                PostCarbonFilterMax = deviceInfo.PostCarbonFilterMax;
                RemineralizationFilterMax = deviceInfo.RemineralizationFilterMax;

                IsRefreshing = false;
            }
            catch (Exception ex)
            {
                clsGvar.ShowMessege(PopupType.Error, 3, "Connection Error!");
            }
        }

        void SignOut()
        {
            Application.Current.MainPage = new LoginPage();
        }
    }
}
