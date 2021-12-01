using Projeto.R4.StartupOne.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Projeto.R4.StartupOne.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            this.BindingContext = new HomeViewModel();
        }
    }
}