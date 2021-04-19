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

            int caseSwitch = 1;

            switch (caseSwitch)
            {
                case 1:
                    await Navigation.PushAsync(new Page1());
                    break;
                case 2:
                    await Navigation.PushAsync(new Page2());
                    break;
                case 3:
                    await Navigation.PushAsync(new Page3());
                    break;
                case 4:
                    await Navigation.PushAsync(new Page4());
                    break;
                default:
                    Console.WriteLine("Default case");
                    break;
            }

       //     await Navigation.PushAsync(new Page1());
     //       await Navigation.PushAsync(new Page2());
     //       await Navigation.PushAsync(new Page3());
     //      await Navigation.PushAsync(new Page4());

        }

        async private void Button_Clicked_2(object sender, EventArgs e)
        {

        }
    }
}
