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
    public partial class Page3 : ContentPage
    {
        public Page3()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            //carga desde BD
            var cat = await App.Database.leerCategoria();
            int cant_cat = cat.Count();
            for (int i = 0; i < cant_cat; i++)
            {
                pickerCatIng.Items.Add(cat[i].Nombre.ToString());
            }

            var prod = await App.Database.leerProducto();
            int cantidad = prod.Count();
            for (int i = 0; i < cantidad; i++)
            {
                pickerProdIng.Items.Add(prod[i].Nombre.ToString());
            }
        }
        async private void Button_Clicked_1(object sender, EventArgs e)
        {
            var cat = pickerCatIng.SelectedItem.ToString();
            var prod = pickerProdIng.SelectedItem.ToString();
            int cntsum = int.Parse(cant_res.Text);


            var cant_prod = await App.Database.leerProductoModInv(prod, cat);
            int cp = cant_prod.Count();

            if (cp == 0)
            {
                await DisplayAlert("Error", "Categoria no contiene producto indicado", "OK");
            }
            else
            {
                int actual = int.Parse(cant_prod[0].Cantidad.ToString());
                int total = actual - cntsum;
                Console.WriteLine(total);
                if (total < 0)
                {
                    await DisplayAlert("Error", "Está retirando más productos de los registrados", "OK");

                }
                else {
                    var cant_mod = await App.Database.UpdateCantProd(cat, prod, total);
                    await DisplayAlert("", "Inventario actualizado", "OK");
                    cant_res.Text = "";
                }
            }


        }
    }
}