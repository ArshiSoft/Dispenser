using System;
using System.Linq;
using System.Threading.Tasks;
using Dispenser.Class;
using Dispenser.Models;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace Dispenser.ViewModels.Forms
{
    /// <summary>
    /// ViewModel for login page.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class LoginPageViewModel : LoginViewModel
    {
        #region Fields

        private string password = "abc";

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="LoginPageViewModel" /> class.
        /// </summary>
        public LoginPageViewModel()
        {
            this.LoginCommand = new Command(this.LoginClicked);
            this.SignUpCommand = new Command(this.SignUpClicked);
            this.ForgotPasswordCommand = new Command(this.ForgotPasswordClicked);
            this.SocialMediaLoginCommand = new Command(this.SocialLoggedIn);
        }

        #endregion

        #region property

        /// <summary>
        /// Gets or sets the property that is bound with an entry that gets the password from user in the login page.
        /// </summary>
        public string Password
        {
            get
            {
                return this.password;
            }

            set
            {
                if (this.password == value)
                {
                    return;
                }

                this.password = value;
                this.OnPropertyChanged();
            }
        }

        #endregion

        #region Command

        /// <summary>
        /// Gets or sets the command that is executed when the Log In button is clicked.
        /// </summary>
        public Command LoginCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that is executed when the Sign Up button is clicked.
        /// </summary>
        public Command SignUpCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that is executed when the Forgot Password button is clicked.
        /// </summary>
        public Command ForgotPasswordCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that is executed when the social media login button is clicked.
        /// </summary>
        public Command SocialMediaLoginCommand { get; set; }

        #endregion

        #region methods

        /// <summary>
        /// Invoked when the Log In button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private async void LoginClicked(object obj)
        {
            if (!Email.Any())
            {
                clsGvar.ShowMessege(PopupType.Warning, 3, "Email cannot be Empty!");
                return;
            }
            if (IsInvalidEmail)
            {
                clsGvar.ShowMessege(PopupType.Warning, 3, "Email is Invalid!");
                return;
            }
            if (!Password.Any())
            {
                clsGvar.ShowMessege(PopupType.Warning, 3, "Password cannot be Empty!");
                return;
            }

            clsGvar.StartWaiting();

            var user = new User
            {
                ID = 0,
                Username = Email,
                Password = CryptorEngine.Encrypt(Password, true)
            };

            try
            {
                var result = await clsGvar.MyAPI.Login(user);
                var resultArray = result.Trim('"').Split(',');

                var rtnValue = resultArray[0].ToBoolean();
                var userType = (UserType)resultArray[1].ToInt32();
                clsGvar.UserType = userType;

                if (!rtnValue)
                {
                    clsGvar.ShowMessege(PopupType.Warning, 3, "Incorrect Username or Password!");
                    return;
                }

                Application.Current.MainPage = new MainPage();

                await clsGvar.PopUpCurrent();
            }
            catch (Exception ex)
            {
                await clsGvar.PopUpCurrent();
                clsGvar.ShowMessege(PopupType.Error, 3, "Connection Error!");
            }
        }

        /// <summary>
        /// Invoked when the Sign Up button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void SignUpClicked(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when the Forgot Password button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private async void ForgotPasswordClicked(object obj)
        {
            var label = obj as Label;
            label.BackgroundColor = Color.FromHex("#70FFFFFF");
            await Task.Delay(100);
            label.BackgroundColor = Color.Transparent;
        }

        /// <summary>
        /// Invoked when social media login button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void SocialLoggedIn(object obj)
        {
            // Do something
        }

        #endregion
    }
}