using Projeto.R4.StartupOne.Models;
using Projeto.R4.StartupOne.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace Projeto.R4.StartupOne.ViewModels
{
    public class ConfigCulturaViewModel : BaseViewModel
    {
        public ObservableCollection<CulturaTemaModel> Temas { get; set; }

        public Command SalvarClicked { get; }

        public ConfigCulturaViewModel()
        {
            Title = "Config. Cultura";
            Temas = ObterMockTemas();
            SalvarClicked = new Command(SalvarConfiguracao);
        }

        private ObservableCollection<CulturaTemaModel> ObterMockTemas()
        {
            return new ObservableCollection<CulturaTemaModel>() {
                new CulturaTemaModel() { Id=1, Descricao="Música",Marcado=true},
                new CulturaTemaModel() { Id=2, Descricao="Cinema"},
                new CulturaTemaModel() { Id=3, Descricao="Gastronomia",Marcado=true},
                new CulturaTemaModel() { Id=4, Descricao="Museu"},
                new CulturaTemaModel() { Id=5, Descricao="Teatro"}
            };
        }

        private void SalvarConfiguracao()
        {
            
        }

    }
}
