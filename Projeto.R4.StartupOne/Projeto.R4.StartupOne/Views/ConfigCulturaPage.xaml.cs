using Projeto.R4.StartupOne.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Projeto.R4.StartupOne.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConfigCulturaPage : ContentPage
    {
        public ConfigCulturaPage()
        {
            InitializeComponent();
            BindingContext = new ConfigCulturaViewModel();
        }

        private void FecharClicked(object sender, EventArgs e)
        {
            
        }

    }
}