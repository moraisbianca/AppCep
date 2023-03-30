using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCep
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Menu : ContentPage
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void CepByLogradouro(object sender, EventArgs e)
        {
            Navigation.PushAsync(new View.BuscaCepPorLogradouro());
        }

        private void LogradouroByCep(object sender, EventArgs e)
        {
            Navigation.PushAsync(new View.BuscaLogradouroByCep());
        }

        private void BairroPorCidade(object sender, EventArgs e)
        {
            Navigation.PushAsync(new View.BairroPorCidade());
        }

        private void CidadeByEstado(object sender, EventArgs e)
        {
            Navigation.PushAsync(new View.BuscaCidadeByEstado());
        }

        private void LogradouroByBairro(object sender, EventArgs e)
        {
            Navigation.PushAsync(new View.BuscaLogByEstadoCidadeBairro());
        }
    }
}