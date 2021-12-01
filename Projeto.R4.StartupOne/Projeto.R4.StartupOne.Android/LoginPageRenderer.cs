using Android.App;
using Projeto.R4.StartupOne.Models;
using Projeto.R4.StartupOne.Views;
using System;
using Xamarin.Auth;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;


[assembly: ExportRenderer(typeof(ProviderLoginPage), typeof(Projeto.R4.StartupOne.Droid.LoginPageRenderer))]
namespace Projeto.R4.StartupOne.Droid
{

    public class LoginPageRenderer : PageRenderer
    {
        [Obsolete]
        public LoginPageRenderer()
        {
            var activity = this.Context as Activity;
            var loginPage = Element as ProviderLoginPage;
            string providername = loginPage.ProviderName;          
            var auth = OAuthProviderSetting.LoginWithProvider(providername);
            auth.Completed += (sender, eventArgs) =>
            {
                if (eventArgs.IsAuthenticated)
                {
                    OAuthConfiguration.User = new User();
                    // Get and Save User Details   
                    OAuthConfiguration.User.Token = eventArgs.Account.Properties["oauth_token"];
                    OAuthConfiguration.User.TokenSecret = eventArgs.Account.Properties["oauth_token_secret"];
                    OAuthConfiguration.User.TwitterId = eventArgs.Account.Properties["user_id"];
                    OAuthConfiguration.User.ScreenName = eventArgs.Account.Properties["screen_name"];


                    //OAuthConfiguration.SuccessfulLoginAction.Invoke();
                }
                else
                {
                    // The user cancelled  
                }
            };
            activity.StartActivity(auth.GetUI(activity));
        }
    }
}