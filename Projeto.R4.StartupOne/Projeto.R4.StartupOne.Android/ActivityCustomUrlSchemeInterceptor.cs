using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Projeto.R4.StartupOne.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projeto.R4.StartupOne.Droid
{
    [Activity(Label = "ActivityCustomUrlSchemeInterceptor", NoHistory = true, LaunchMode = LaunchMode.SingleTop)]
    //[IntentFilter(
    //    new[] { Intent.ActionView },
    //    Categories = new[] { Intent.CategoryDefault, Intent.CategoryBrowsable },
    //    DataSchemes = new[] { "Projeto.R4.StartupOne" },
    //    DataPath = "/oauth2redirect")]
    public class ActivityCustomUrlSchemeInterceptor : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            global::Android.Net.Uri uri_android = Intent.Data;
            // Convert Android.Net.Url to Uri
            var uri = new Uri(uri_android.ToString());

            // Close browser 
            var intent = new Intent(this, typeof(MainActivity));
            //intent.SetFlags(ActivityFlags.ClearTop | ActivityFlags.SingleTop);
            StartActivity(intent);

            // Load redirectUrl page
            OAuthProviderSetting.AuthenticationState.OnPageLoading(uri);

            this.Finish();

            // Create your application here
        }
    }
}