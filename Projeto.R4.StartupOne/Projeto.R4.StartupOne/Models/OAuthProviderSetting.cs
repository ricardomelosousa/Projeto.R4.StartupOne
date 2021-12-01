using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Auth;

namespace Projeto.R4.StartupOne.Models
{
    public static class OAuthProviderSetting
    {
        public static OAuth2Authenticator AuthenticationState { get; private set; }
        public static OAuth1Authenticator LoginTwitterAuth()
        {
            OAuth1Authenticator twitter = new OAuth1Authenticator(
                            consumerKey: "*****",
                            consumerSecret: "****",
                            requestTokenUrl: new Uri("https://api.twitter.com/oauth/request_token"),
                            authorizeUrl: new Uri("https://api.twitter.com/oauth/authorize"),
                            accessTokenUrl: new Uri("https://api.twitter.com/oauth/access_token"),
                            callbackUrl: new Uri("http://www.devenvexe.com"));

            return twitter;
        }

        public static OAuth2Authenticator LoginWithProvider(string providername)
        {


            if (string.IsNullOrEmpty(providername) && providername == "facebook")
            {
                var face = new OAuth2Authenticator(
                  clientId: "180XXXXX20029269",
                  scope: "",
                  authorizeUrl: new Uri("https://m.facebook.com/dialog/oauth/"),
                  redirectUrl: new Uri("http://www.facebook.com/connect/login_success.html"));
                AuthenticationState = face;
                return face;
            }
            else if (string.IsNullOrEmpty(providername) && providername == "gmail")
            {
                var gmail = new OAuth2Authenticator(
                        "ClientId",
                        "ClientSecret",
                        "https://www.googleapis.com/auth/userinfo.email",
                        new Uri("https://accounts.google.com/o/oauth2/auth"),
                        new Uri("http://www.devenvexe.com"),
                        new Uri("https://accounts.google.com/o/oauth2/token"));
                AuthenticationState = gmail;
                return gmail;
            }
            return null;
        }
    }
}
