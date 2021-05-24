using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prueba4.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdmBodega : ContentPage
    {
        public AdmBodega()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            colectionBod.ItemsSource = await App.Database.GetBodegaAsync();

        }
        async void creaBod(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(entradaNombreBod.Text))
            {

                await App.Database.SaveBodegaAsync(new LocalDatabase.Bodega
                {
                    Nombre = entradaNombreBod.Text,
                }); ;

                entradaNombreBod.Text = string.Empty;

                colectionBod.ItemsSource = await App.Database.GetBodegaAsync();

            }
        }
    }
}