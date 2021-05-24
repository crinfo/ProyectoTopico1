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
    public partial class AdmCategoria : ContentPage
    {
        public AdmCategoria()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            colectionCat.ItemsSource = await App.Database.GetCategoriaAsync();

        }
        async void crearCat(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(entradaNombreCat.Text))
            {

                await App.Database.SaveCategoriaAsync(new LocalDatabase.Categoria
                {
                    Nombre = entradaNombreCat.Text,
                }); ;

                entradaNombreCat.Text = string.Empty;

                colectionCat.ItemsSource = await App.Database.GetCategoriaAsync();

            }
        }
    }
}