using Projeto.R4.StartupOne.Data.ConfigurationSqlite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Projeto.R4.StartupOne.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        UsuarioDatabase database;
        public HomeViewModel()
        {
            Title = "Home";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
            database = new UsuarioDatabase();   

        }

        public async void CarregarDadosUsuarioLogado() 
        {
            //Secure Storage
           var usuarioSecure = await SecureStorage.GetAsync("credentials");

            //Sqlite
            var usuarioSqlite = await database.GetLastItemAsync();

        }

        public ICommand OpenWebCommand { get; }
    }
}
