using Prueba4.views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Prueba4
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async private void Button_Login(object sender, EventArgs e)
        {
            var usr = usuario.Text;
            var pass = clave.Text;

                if (usr=="super") {
                    await Navigation.PushAsync(new Page1());
                }
                else { 
                    var perfil = await App.Database.leeUsuario(usr,pass);
                    int esper = perfil.Count();
                Console.WriteLine(esper);
                    if (esper == 0)
                    {
                        await DisplayAlert("Error", "Usuario/Clave inválida", "OK");
                    }
                    else
                    {
                        var usrPerfil = perfil[0].Perfil.ToString();
                    Console.WriteLine(usrPerfil);
                        switch (usrPerfil)
                        {
                            case "Administrador":
                                await Navigation.PushAsync(new Page1());

                                break;
                            case "Ingreso":
                                await Navigation.PushAsync(new Page2());

                                break;
                            case "Retiro":
                                await Navigation.PushAsync(new Page3());

                                break;
                            case "Consulta":
                                await Navigation.PushAsync(new Page4());
                                break;
                            default:
                                await DisplayAlert("Error", "Usuario/Clave inválida", "OK");
                                break;
                        }
                    }
                }
            
        }
    }
}
