﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prueba4.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        public Page1()
        {
            InitializeComponent();
        }

        async private void Button_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

        async private void ico_user(object sender, EventArgs e)
        {
            await Navigation.PushAsync(page: new MainPage());

        }
        async private void ico_prod(object sender, EventArgs e)
        {
            await Navigation.PushAsync(page: new MainPage());

        }
        async private void ico_bod(object sender, EventArgs e)
        {
            await Navigation.PushAsync(page: new MainPage());

        }
        async private void ico_cat(object sender, EventArgs e)
        {
            await Navigation.PushAsync(page: new MainPage());

        }
    }
}