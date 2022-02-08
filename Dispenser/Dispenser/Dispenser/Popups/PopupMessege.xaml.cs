using System;
using System.Collections.Generic;
using System.Timers;
using Dispenser.Class;
using Rg.Plugins.Popup.Pages;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Dispenser.Popups
{
    public partial class PopupMessege : PopupPage
    {
        Timer timer = new Timer(1000);
        int count = 0;
        int sec = 1;
        PopupType thisType = PopupType.Success;
        public PopupMessege(PopupType type, int seconds, string Messege)
        {
            InitializeComponent();
            thisType = type;
            sec = seconds;
            lblMessege.Text = Messege;
            timer.Elapsed += Timer_Elapsed;
            timer.Enabled = false;
            timer.Stop();
        }

        private async void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            count++;
            if (count >= sec)
            {
                timer.Enabled = false;
                timer.Stop();
                await clsGvar.PopUpCurrent();
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            SettingType();

            timer.Enabled = true;
            timer.Start();
            Vibration.Vibrate(200);
        }

        private void SettingType()
        {
            switch (thisType)
            {
                case PopupType.Success:
                    img.Source = "Success.png";
                    break;
                case PopupType.Error:
                    img.Source = "Error.png";
                    break;
                case PopupType.Warning:
                    img.Source = "Warning.png";
                    break;
                case PopupType.Info:
                    img.Source = "Info.png";
                    break;
            }
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await clsGvar.PopUpCurrent();
        }
        protected override void OnDisappearingAnimationBegin()
        {
            sec = 1000;
            timer.Enabled = false;
            timer.Stop();
            base.OnDisappearingAnimationBegin();
        }

        private async void SwipeGestureRecognizer_Swiped(object sender, SwipedEventArgs e)
        {
            if (e.Direction == SwipeDirection.Up)
                await clsGvar.PopUpCurrent();
        }
    }
}
