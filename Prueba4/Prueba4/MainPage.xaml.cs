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

        async private void Button_Clicked_1(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new Page1());
        }

        async private void Button_Clicked_2(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Page2());

        }
        async private void Button_Clicked_3(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Page3());

        }
        async private void Button_Clicked_4(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Page4());

        }

    }
}
