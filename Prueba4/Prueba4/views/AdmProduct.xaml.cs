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
    public partial class AdmProduct : ContentPage
    {
        public AdmProduct()
        {
            InitializeComponent();
        }
  
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        colectionPrd.ItemsSource = await App.Database.GetProductoAsync();
            //carga desde BD
            var prueba = await App.Database.leerCategoria();
            int cantidad = prueba.Count();
            for (int i =0;i<cantidad;i++) {
                selCat.Items.Add(prueba[i].Nombre.ToString());
            }

        }
        async void crearPrd(object sender, EventArgs e)
        {
            var catsel= selCat.SelectedItem.ToString();
            if (catsel=="") {
                await DisplayAlert("Error", "Debe Generar una Categoría", "OK");
            }
            else
            { 
       
            if (!string.IsNullOrWhiteSpace(entradaNombreProd.Text))
            {

                await App.Database.SaveProductoAsync(new LocalDatabase.Producto
                {
                    Nombre = entradaNombreProd.Text,
                    Categoria = selCat.SelectedItem.ToString(),
                    Cantidad=0
                }); ;

                entradaNombreProd.Text = string.Empty;
                colectionPrd.ItemsSource = await App.Database.GetProductoAsync();
            }
        }
    }
    }

}