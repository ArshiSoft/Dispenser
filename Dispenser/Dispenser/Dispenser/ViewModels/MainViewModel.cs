using Dispenser.Class;
using Dispenser.Models;
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
        string tempname = "Cold";
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
        Color sedimentalfiltercolor = Color.Red;
        Color gacfiltercolor = Color.Red;
        Color carbonfiltercolor = Color.Red;
        Color rofiltercolor = Color.Red;
        Color postcarbonfiltercolor = Color.Red;
        Color remineralizationfiltercolor = Color.Red;
        string sedimentalfilterhealth;
        string gacfilterhealth;
        string carbonfilterhealth;
        string rofilterhealth;
        string postcarbonfilterhealth;
        string remineralizationfilterhealth;
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

            Temperatures = new ObservableCollection<Temperature>()
            {
                new Temperature
                {
                    TempName = "Cold",
                    TempInCelcius = 8
                },
                new Temperature
                {
                    TempName = "Hot",
                    TempInCelcius = 48
                }
            };

            RefreshCommand = new Command(Refresh);
            SignOutCommand = new Command(SignOut);
        }
        public ObservableCollection<Temperature> Temperatures { get; set; }

        public ICommand RefreshCommand { get; }
        public ICommand SignOutCommand { get; }

        public DateTime Date
        {
            get { return date; }
            set { SetProperty(ref date, value); }
        }

        public string TempName
        {
            get { return tempname; }
            set { SetProperty(ref tempname, value); }
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

        public Color SedimentalFilterColor
        {
            get { return sedimentalfiltercolor; }
            set { SetProperty(ref sedimentalfiltercolor, value); }
        }

        public Color GACFilterColor
        {
            get { return gacfiltercolor; }
            set { SetProperty(ref gacfiltercolor, value); }
        }

        public Color CarbonFilterColor
        {
            get { return carbonfiltercolor; }
            set { SetProperty(ref carbonfiltercolor, value); }
        }

        public Color ROFilterColor
        {
            get { return rofiltercolor; }
            set { SetProperty(ref rofiltercolor, value); }
        }

        public Color PostCarbonFilterColor
        {
            get { return postcarbonfiltercolor; }
            set { SetProperty(ref postcarbonfiltercolor, value); }
        }

        public Color RemineralizationFilterColor
        {
            get { return remineralizationfiltercolor; }
            set { SetProperty(ref remineralizationfiltercolor, value); }
        }

        public string SedimentalFilterHealth
        {
            get { return sedimentalfilterhealth; }
            set { SetProperty(ref sedimentalfilterhealth, value); }
        }

        public string GACFilterHealth
        {
            get { return gacfilterhealth; }
            set { SetProperty(ref gacfilterhealth, value); }
        }

        public string CarbonFilterHealth
        {
            get { return carbonfilterhealth; }
            set { SetProperty(ref carbonfilterhealth, value); }
        }

        public string ROFilterHealth
        {
            get { return rofilterhealth; }
            set { SetProperty(ref rofilterhealth, value); }
        }

        public string PostCarbonFilterHealth
        {
            get { return postcarbonfilterhealth; }
            set { SetProperty(ref postcarbonfilterhealth, value); }
        }

        public string RemineralizationFilterHealth
        {
            get { return remineralizationfilterhealth; }
            set { SetProperty(ref remineralizationfilterhealth, value); }
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
                SedimentalFilterMax = SedimentalFilter > deviceInfo.SedimentalFilterMax ? SedimentalFilter : deviceInfo.SedimentalFilterMax;
                GACFilterMax = GACFilter > deviceInfo.GACFilterMax ? GACFilter : deviceInfo.GACFilterMax;
                CarbonFilterMax = CarbonFilter > deviceInfo.CarbonFilterMax ? CarbonFilter : deviceInfo.CarbonFilterMax;
                ROFilterMax = ROFilter > deviceInfo.ROMembraneFilterMax ? ROFilter : deviceInfo.ROMembraneFilterMax;
                PostCarbonFilterMax = PostCarbonFilter > deviceInfo.PostCarbonFilterMax ? PostCarbonFilter : deviceInfo.PostCarbonFilterMax;
                RemineralizationFilterMax = RemineralizationFilter > deviceInfo.RemineralizationFilterMax ? RemineralizationFilter : deviceInfo.RemineralizationFilterMax;

                Temperatures[0].TempInCelcius = ColdTempSensor;
                Temperatures[1].TempInCelcius = HotTempSensor;

                if (SedimentalFilter <= (SedimentalFilterMax / 2))
                {
                    SedimentalFilterHealth = "Good";
                    SedimentalFilterColor = Color.FromHex("#2699FB");
                }
                else if (SedimentalFilter > (SedimentalFilterMax / 2) && SedimentalFilter <= (SedimentalFilterMax - (SedimentalFilterMax / 4)))
                {
                    SedimentalFilterHealth = "Normal";
                    SedimentalFilterColor = Color.DarkGreen;
                }
                else if (SedimentalFilter > (SedimentalFilterMax - (SedimentalFilterMax / 4)) && SedimentalFilter < SedimentalFilterMax)
                {
                    SedimentalFilterHealth = "Bad";
                    SedimentalFilterColor = Color.Red;
                }
                else
                {
                    SedimentalFilterHealth = "Change";
                    SedimentalFilterColor = Color.Red;
                }

                if (CarbonFilter <= (CarbonFilterMax / 2))
                {
                    CarbonFilterHealth = "Good";
                    CarbonFilterColor = Color.FromHex("#2699FB");
                }
                else if (CarbonFilter > (CarbonFilterMax / 2) && CarbonFilter <= (CarbonFilterMax - (CarbonFilterMax / 4)))
                {
                    CarbonFilterHealth = "Normal";
                    CarbonFilterColor = Color.DarkGreen;
                }
                else if (CarbonFilter > (CarbonFilterMax - (CarbonFilterMax / 4)) && CarbonFilter < CarbonFilterMax)
                {
                    CarbonFilterHealth = "Bad";
                    CarbonFilterColor = Color.Red;
                }
                else
                {
                    CarbonFilterHealth = "Change";
                    CarbonFilterColor = Color.Red;
                }

                if (GACFilter <= (GACFilterMax / 2))
                {
                    GACFilterHealth = "Good";
                    GACFilterColor = Color.FromHex("#2699FB");
                }
                else if (GACFilter > (GACFilterMax / 2) && GACFilter <= (GACFilterMax - (GACFilterMax / 4)))
                {
                    GACFilterHealth = "Normal";
                    GACFilterColor = Color.DarkGreen;
                }
                else if (GACFilter > (GACFilterMax - (GACFilterMax / 4)) && GACFilter < GACFilterMax)
                {
                    GACFilterHealth = "Bad";
                    GACFilterColor = Color.Red;
                }
                else
                {
                    GACFilterHealth = "Change";
                    GACFilterColor = Color.Red;
                }

                if (ROFilter <= (ROFilterMax / 2))
                {
                    ROFilterHealth = "Good";
                    ROFilterColor = Color.FromHex("#2699FB");
                }
                else if (ROFilter > (ROFilterMax / 2) && ROFilter <= (ROFilterMax - (ROFilterMax / 4)))
                {
                    ROFilterHealth = "Normal";
                    ROFilterColor = Color.DarkGreen;
                }
                else if (ROFilter > (ROFilterMax - (ROFilterMax / 4)) && ROFilter < ROFilterMax)
                {
                    ROFilterHealth = "Bad";
                    ROFilterColor = Color.Red;
                }
                else
                {
                    ROFilterHealth = "Change";
                    ROFilterColor = Color.Red;
                }

                if (PostCarbonFilter <= (PostCarbonFilterMax / 2))
                {
                    PostCarbonFilterHealth = "Good";
                    PostCarbonFilterColor = Color.FromHex("#2699FB");
                }
                else if (PostCarbonFilter > (PostCarbonFilterMax / 2) && PostCarbonFilter <= (PostCarbonFilterMax - (PostCarbonFilterMax / 4)))
                {
                    PostCarbonFilterHealth = "Normal";
                    PostCarbonFilterColor = Color.DarkGreen;
                }
                else if (PostCarbonFilter > (PostCarbonFilterMax - (PostCarbonFilterMax / 4)) && PostCarbonFilter < PostCarbonFilterMax)
                {
                    PostCarbonFilterHealth = "Bad";
                    PostCarbonFilterColor = Color.Red;
                }
                else
                {
                    PostCarbonFilterHealth = "Change";
                    PostCarbonFilterColor = Color.Red;
                }

                if (RemineralizationFilter <= (RemineralizationFilterMax / 2))
                {
                    RemineralizationFilterHealth = "Good";
                    RemineralizationFilterColor = Color.FromHex("#2699FB");
                }
                else if (RemineralizationFilter > (RemineralizationFilterMax / 2) && RemineralizationFilter <= (RemineralizationFilterMax - (RemineralizationFilterMax / 4)))
                {
                    RemineralizationFilterHealth = "Normal";
                    RemineralizationFilterColor = Color.DarkGreen;
                }
                else if (RemineralizationFilter > (RemineralizationFilterMax - (RemineralizationFilterMax / 4)) && RemineralizationFilter < RemineralizationFilterMax)
                {
                    RemineralizationFilterHealth = "Bad";
                    RemineralizationFilterColor = Color.Red;
                }
                else
                {
                    RemineralizationFilterHealth = "Change";
                    RemineralizationFilterColor = Color.Red;
                }

                if (SedimentalFilterHealth == "Change" ||
                    GACFilterHealth == "Change" ||
                    CarbonFilterHealth == "Change" ||
                    ROFilterHealth == "Change" ||
                    PostCarbonFilterHealth == "Change" ||
                    RemineralizationFilterHealth == "Change")
                {
                    var message = "These filters Must be changed:\n";

                    if (SedimentalFilterHealth == "Change")
                        message += "\nSedimental Filter";
                    if (GACFilterHealth == "Change")
                        message += "\nGAC Filter";
                    if (CarbonFilterHealth == "Change")
                        message += "\nCarbon Filter";
                    if (ROFilterHealth == "Change")
                        message += "\nRO Memberane Filter";
                    if (PostCarbonFilterHealth == "Change")
                        message += "\nPost Carbon Filter";
                    if (RemineralizationFilterHealth == "Change")
                        message += "\nRemineralization Filter";

                    await Application.Current.MainPage.DisplayAlert("Filters Expired!", message, "OK");
                }

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
