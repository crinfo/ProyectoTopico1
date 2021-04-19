using Prueba4.views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prueba4
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage  = new MainPage();//--> descomentar para volver a main page
            // se debe eliminar la primera para poder usar el segundo comando
            // MainPage =  new NavigationPage(new Page1());
            MainPage =  new NavigationPage(new MainPage());


        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
