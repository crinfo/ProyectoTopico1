using Prueba4.views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using LocalDatabase;

namespace Prueba4
{
    public partial class App : Application
    {

        static Database database;

        public static Database Database
        {
            get
            {
                if (database == null)
                {
                    database = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "people.db3"));
                }
                return database;
            }
        }

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
