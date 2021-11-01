﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CountryAppISO3166.ViewModels;

namespace CountryAppISO3166.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registro : ContentPage
    {
        public Registro()
        {
            var vm = new RegisterViewModel();
            this.BindingContext = vm;
            InitializeComponent();

            Email.Completed += (object sender, EventArgs e) =>
            {
                Password.Focus();
            };

            Password.Completed += (object sender, EventArgs e) =>
            {
                //vm.SubmitCommand.Execute(null);
                ConfirmPassword.Focus();
            };

        }
    }
}