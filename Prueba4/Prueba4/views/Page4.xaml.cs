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
    public partial class Page4 : ContentPage
    {
        public Page4()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            //carga desde BD
            var prod = await App.Database.leerProducto();
            int cantidad = prod.Count();
            Console.WriteLine(cantidad);
            for (int i = 0; i < cantidad; i++)
            {
                pickerProdIng.Items.Add(prod[i].Nombre.ToString());
            }
        }

        async private void cons_cant(object sender, EventArgs e)
        {
            var prod = pickerProdIng.SelectedItem.ToString();
            var productos = await App.Database.leerProductoCant(prod);
            Console.WriteLine(productos[0].Cantidad.ToString());

            colectionUsr.ItemsSource = await App.Database.leerProductoCant(prod);




        }
    }
}