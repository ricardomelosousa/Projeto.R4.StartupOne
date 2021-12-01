using Newtonsoft.Json;
using Projeto.R4.StartupOne.Data.ConfigurationSqlite;
using Projeto.R4.StartupOne.Models;
using Projeto.R4.StartupOne.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using Xamarin.Auth;
using Xamarin.Auth.Presenters;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Projeto.R4.StartupOne.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        HttpClient client;
        OAuth2Authenticator oAuth2Authenticator;
        OAuth1Authenticator oAuth1Authenticator;
        UsuarioDatabase database;

        public static EventHandler OnPresenter;      
        private string email;
        private string password;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                SetProperty(ref email, value);
            }
        }
     
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                SetProperty(ref password, value);
            }
        }
        public ICommand SubmitCommand { protected set; get; }
        public ICommand SubmitOauthGmailCommand { protected set; get; }
        public ICommand SubmitOauthFaceCommand { protected set; get; }
        public ICommand SubmitOauthTwitterCommand { protected set; get; }
        public LoginViewModel()
        {
            SubmitCommand = new Command(OnSubmit);
            SubmitOauthGmailCommand = new Command(OnAouthGmailSubmit);
            SubmitOauthGmailCommand = new Command(OnAouthFaceSubmit);
            SubmitOauthGmailCommand = new Command(OnAouthTwitterSubmit);

            client = new HttpClient();
            client.BaseAddress = new Uri($"{App.ApiBackendUrl}/");
            CarregarDados();

        }

        public async void CarregarDados()
        {
            database = new UsuarioDatabase();
            var login = await database.GetLastItemAsync();
            if (login != null)
            {
                Email = login.Login;
                Password = login.Password;
            }

        }

        private void OnAouthGmailSubmit()
        {
            LoginOAuth2("gmail");
        }
        private void OnAouthFaceSubmit()
        {
            LoginOAuth2("facebook");
        }
        private void OnAouthTwitterSubmit()
        {
            LoginOAuth2("twitter");
        }

        public async void OnSubmit()
        {
            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
            {
                string title = "Authentication Error";
                string msg = "Usuário ou senha invalidos";
                await Application.Current.MainPage.DisplayAlert(title, msg, "OK");
            }
            else
            {
                var loginRequest = new LoginRequest() { Login = Email, Password = Password };
                var serializedLogin = JsonConvert.SerializeObject(loginRequest);
                var response = await client.PostAsync($"api/usuario/autentication", new StringContent(serializedLogin, Encoding.UTF8, "application/json"));
                if (response.IsSuccessStatusCode)
                {
                    //salvar sqlite
                    var login = JsonConvert.DeserializeObject<LoginRequest>(await response.Content.ReadAsStringAsync());
                    await database.SaveItemAsync(login);
                    //Secure Storage
                    await SecureStorage.SetAsync("credentials", JsonConvert.SerializeObject(login));

                    await Shell.Current.GoToAsync("//HomePage");
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Erro ao logar", "Verifique credenciais de acesso", "OK");
                }
            }
            await Shell.Current.GoToAsync("//HomePage");

        }

        private void LoginOAuth2(string provider)
        {
            var presenter = new OAuthLoginPresenter();
            if (provider != "twitter")
            {
                oAuth2Authenticator = OAuthProviderSetting.LoginWithProvider(provider);
                oAuth2Authenticator.Completed += OAuth2Authenticator_Completed;
                oAuth2Authenticator.Error += OAuth2Authenticator_Error;
                presenter.Login(oAuth2Authenticator);
            }
            else
            {
                oAuth1Authenticator = OAuthProviderSetting.LoginTwitterAuth();
                oAuth1Authenticator.Completed += OAuth2Authenticator_Completed;
                oAuth1Authenticator.Error += OAuth2Authenticator_Error;
                presenter.Login(oAuth1Authenticator);
            }




        }

        private async void OAuth2Authenticator_Error(object sender, AuthenticatorErrorEventArgs e)
        {
            await Application.Current.MainPage.DisplayAlert("Erro ao logar", "Verifique credenciais de acesso junto ao seu provedor.", "OK");
        }

        private async void OAuth2Authenticator_Completed(object sender, AuthenticatorCompletedEventArgs e)
        {
            if (e.IsAuthenticated)
            {
                try
                {
                    var login = new LoginRequest();
                    login.AccessToken = e.Account.Properties["access_token"];
                    login.Login = Email;
                    login.Password = Password;
                    //Sqlite
                    await database.SaveItemAsync(login);
                    //Secure Storage
                    await SecureStorage.SetAsync("credentials", JsonConvert.SerializeObject(login));
                    await Application.Current.MainPage.Navigation.PushAsync(new HomePage());
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
            else
            {
                oAuth2Authenticator.OnCancelled();
                oAuth2Authenticator = default(OAuth2Authenticator);
            }
        }
    }
}
