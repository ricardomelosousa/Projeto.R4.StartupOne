using Projeto.R4.StartupOne.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace Projeto.R4.StartupOne.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}