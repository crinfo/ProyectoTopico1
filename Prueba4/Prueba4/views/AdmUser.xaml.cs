 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prueba4.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdmUser : ContentPage
    {
        public AdmUser()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            colectionUsr.ItemsSource = await App.Database.GetPeopleAsync();

        }
        async void crearUsr(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(entradaNombre.Text) && !string.IsNullOrWhiteSpace(entradaCorreo.Text) && !string.IsNullOrWhiteSpace(entradaPass.Text))
            {
                string perf = "";
                switch (seleccionPerfil.SelectedIndex) {
                    case 0:
                        perf = "Administrador";
                        break;
                    case 1:
                        perf="Ingreso";
                        break;
                    case 2:
                        perf = "Retiro";
                        break;
                    case 3:
                        perf = "Consulta";
                        break;
                }
                await App.Database.SavePersonAsync(new LocalDatabase.Persona
                {
                    Nombre = entradaNombre.Text,
                    Correo = entradaCorreo.Text,
                    Pass = entradaPass.Text,
                    Estado = 1,
                    Perfil = perf
                }); ;

                entradaNombre.Text = entradaCorreo.Text = entradaPass.Text = string.Empty;

                colectionUsr.ItemsSource = await App.Database.GetPeopleAsync();
                
            }
        }

        async void ActDesactUsr(object sender, EventArgs e)
        {
            int estAct = 0;
            if (seleccionEstado.SelectedIndex == 0)
            {
                estAct = 1;
            }
            else
            {
                estAct = 0;
            }
            await App.Database.UpdateAsyncPersona(estAct,Convert.ToInt32(IdUsrActDesac.Text));
            await DisplayAlert("", "Estado Actualizado", "OK");

            colectionUsr.ItemsSource = await App.Database.GetPeopleAsync();

        }

    }
}