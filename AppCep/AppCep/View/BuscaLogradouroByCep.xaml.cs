using AppCep.Model;
using AppCep.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCep.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BuscaLogradouroByCep : ContentPage
    {
        public BuscaLogradouroByCep()
        {
            InitializeComponent();
        }


        private async void busca(object sender, EventArgs e)
        {
            try
            {
                carregando.IsRunning = true;

                Endereco arr_logradouros = await DataService.GetEnderecoByCep(txt_cep.Text);
                List<Endereco> arr_ = new List<Endereco>()
                {
                    arr_logradouros
                };

                lst_logradouros.ItemsSource = arr_;
                
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ops", ex.Message, "OK");
            }
            finally
            {
                carregando.IsRunning = false;
            }
        }
    }
}