using Projeto.R4.StartupOne.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Projeto.R4.StartupOne.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel();
        }

        public void OnClickLoginAuth(object sender, EventArgs args)
        {
            
            Button btncontrol = (Button)sender;
            string providername = btncontrol.Text;           
            Navigation.PushModalAsync(new ProviderLoginPage(providername));              
            
        }
    }
}