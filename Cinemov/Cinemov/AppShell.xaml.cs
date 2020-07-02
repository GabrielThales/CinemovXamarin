using Cinemov.Views;
using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Cinemov
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            if (App.SessionId == null)
            {
                Navigation.PushModalAsync(new LoginPage());
            }
        }
    }
}
