using System;
using System.Collections.Generic;
using Dispenser.Class;
using Rg.Plugins.Popup.Pages;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Dispenser.Popups
{
    public partial class PopupVerification : PopupPage
    {
        public PopupVerification(VerificationType verificationType)
        {
            InitializeComponent();
            switch (verificationType)
            {
                case VerificationType.Email:
                    lblTitle.Text = "Verify your Email";
                    lblInfo.Text = "We have sent an Email to your Email Address. Please verify the pin code in the email and enter the pin code here.";
                    break;
                case VerificationType.Contact:
                    lblTitle.Text = "Verify your Phone";
                    lblInfo.Text = "We have sent a Messege to your Phone Number. Please verify the pin code in the messege and enter the pin code here.";
                    break;
            }
            txtPin.Focus();
            DeviceDisplay.MainDisplayInfoChanged += OnMainDisplayInfoChanged;
        }

        async void VerifyPin(object sender, EventArgs e)
        {
            clsGvar.EnteredVerificationCode = txtPin.Text.ToInt32();

            if (clsGvar.EnteredVerificationCode == clsGvar.RandomVerificationCode)
            {
                await clsGvar.PopUpAll();
                return;
            }
            else
            {
                txtPin.Text = "";
                clsGvar.EnteredVerificationCode = 0;
                return;
            }
        }

        async void Cancel_Clicked(System.Object sender, System.EventArgs e)
        {
            await clsGvar.PopUpAll();
        }

        async void TapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {
            await clsGvar.PopUpAll();
        }
        private void OnMainDisplayInfoChanged(object sender, DisplayInfoChangedEventArgs e)
        {
            if (e.DisplayInfo.Orientation == DisplayOrientation.Portrait)
            {
                mainFrame.HorizontalOptions = LayoutOptions.CenterAndExpand;
            }
            else if (e.DisplayInfo.Orientation == DisplayOrientation.Landscape)
            {
                mainFrame.HorizontalOptions = LayoutOptions.CenterAndExpand;
                mainFrame.WidthRequest = 500;
            }
            else
            {
                mainFrame.HorizontalOptions = LayoutOptions.CenterAndExpand;
                mainFrame.WidthRequest = 500;
            }
        }
    }
}
