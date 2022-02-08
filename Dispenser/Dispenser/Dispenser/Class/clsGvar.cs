using System;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;
using Dispenser.API;
using Dispenser.Popups;
using Refit;
using Rg.Plugins.Popup.Services;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Dispenser.Class
{
    #region ENUM Functions

    public enum SMSType
    {
        Verification,
        AccountRequestSent,
        AccountApproved,
        AccountRejected
    }
    public enum EmailType
    {
        Verification,
        AccountRequestSent,
        AccountApproved,
        AccountRejected
    }
    public enum VerificationType
    {
        Email,
        Contact
    }
    public enum PopupType
    {
        Success,
        Error,
        Warning,
        Info
    }
    public enum LoginType
    {
        Normal,
        FingerPrint,
        FaceID
    }
    public enum DisplayMode
    {
        Light,
        Dark,
        Unspecified
    }
    public enum CheckState
    {
        Checked = 1,
        UnChecked = 2,
        Intermediate = 3
    }
    public enum UserType
    {
        Consumer = 1,
        Employee = 2
    }

    #endregion ENUM Functions


    public static class clsGvar
    {
        #region IMYAPI

        internal static IMyAPI MyAPI { get; set; } = RestService.For<IMyAPI>("http://161.97.157.214:86");

        #endregion IMYAPI

        #region Variables

        public static int UserID { get; set; }
        public static string Username { get; set; }
        public static string Email { get; set; }
        public static string Password { get; set; }
        public static UserType UserType { get; set; }
        public static int RandomVerificationCode { get; set; }
        public static int EnteredVerificationCode { get; set; }
        public static bool IsRememberMe { get; set; } = false;
        public static bool IsBioLogin { get; set; } = false;
        public static LoginType AppLoginType { get; set; } = LoginType.Normal;
        public static DisplayMode AppDisplayMode { get; set; }

        #endregion Variables

        #region Environment Variables

        public const string Environment_RememberMe = "AS_D_RememberMe";
        public const string Environment_BioLogin = "AS_D_BioLogin";
        public const string Environment_UserName = "AS_D_UserName";
        public const string Environment_Password = "AS_D_Password";

        #endregion Environment Variables

        #region Popup Functions

        public static async void ShowMessege(PopupType type, int seconds, string Messege)
        {
            await PopupNavigation.Instance.PushAsync(new PopupMessege(type, seconds, Messege), true);
        }
        public static async void StartWaiting()
        {
            await PopupNavigation.Instance.PushAsync(new PopupWaiting(), true);
        }
        public static async void ShowVerificationPopup(VerificationType verificationType)
        {
            await PopupNavigation.Instance.PushAsync(new PopupVerification(verificationType), true);
        }
        public static async Task PopUpAll()
        {
            if (PopupNavigation.Instance.PopupStack.Any())
            {
                await PopupNavigation.Instance.PopAllAsync(true);
            }
        }
        public static async Task PopUpCurrent()
        {
            if (PopupNavigation.Instance.PopupStack.Any())
            {
                await PopupNavigation.Instance.PopAsync(true);
            }
        }

        #endregion Popup Functions

        #region Environment Functions

        public static void SetKeyValue(string keyName, object value)
        {
            if (Application.Current.Properties.ContainsKey(keyName))
            {
                Application.Current.Properties[keyName] = value;
            }
            else
            {
                Application.Current.Properties.Add(keyName, value);
            }
        }
        public static object GetKeyValue(string keyName, object valueIfNotExist)
        {
            if (Application.Current.Properties.ContainsKey(keyName))
            {
                return Application.Current.Properties[keyName];
            }
            else
            {
                Application.Current.Properties.Add(keyName, valueIfNotExist);

                return valueIfNotExist;
            }
        }

        #endregion Environment Functions

        #region Image Processing

        public async static Task<string> LoadPhotoAsync(this FileResult photo)
        {
            string PhotoPath = null;
            if (photo == null)
            {
                return PhotoPath;
            }
            // save the file into local storage
            var newFile = Path.Combine(FileSystem.CacheDirectory, photo.FileName);
            using (var stream = await photo.OpenReadAsync())
            using (var newStream = File.OpenWrite(newFile))
                await stream.CopyToAsync(newStream);

            PhotoPath = newFile;

            return PhotoPath;
        }
        public static async Task<Stream> GetStreamFromImageSourceAsync(StreamImageSource imageSource, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (imageSource.Stream != null)
            {
                return await imageSource.Stream(cancellationToken);
            }
            return null;
        }
        public static byte[] GetBytesFromImageSource(this ImageSource imageSource)
        {
            StreamImageSource streamImageSource = (StreamImageSource)imageSource;
            System.Threading.CancellationToken cancellationToken = System.Threading.CancellationToken.None;
            Task<Stream> task = streamImageSource.Stream(cancellationToken);
            Stream stream = task.Result;
            MemoryStream ms = new MemoryStream();
            stream.CopyTo(ms);

            task.Dispose();
            stream.Dispose();

            return ms.ToArray();
        }

        #endregion Image Processing

        #region Email or Phone Verification

        public static bool IsValidEmail(string Email)
        {
            try
            {
                MailAddress m = new MailAddress(Email);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        #endregion Email or Phone Verification
    }
}
