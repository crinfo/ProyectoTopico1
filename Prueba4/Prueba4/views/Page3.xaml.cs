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

        async private void Button_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

        async private void ico_catRet(object sender, EventArgs e)
        {
            await Navigation.PushAsync(page: new MainPage());

        }
        async private void ico_prodRet(object sender, EventArgs e)
        {
            await Navigation.PushAsync(page: new MainPage());

        }
    }
}