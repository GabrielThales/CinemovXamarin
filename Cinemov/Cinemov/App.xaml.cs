using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Cinemov.Views;
using Cinemov.Domain.Services;
using Cinemov.Domain.Interfaces;
using Cinemov.Infra.Repositories;
using Xamarin.Essentials;

namespace Cinemov
{
    public partial class App : Application
    {
        public static AvaliacaoService AvaliacaoService;
        public static string SessionId;
        public App()
        {
            InitializeComponent();
            AvaliacaoService = new AvaliacaoService(new AvaliacaoRepository());
            SessionId = SecureStorage.GetAsync("session_id").Result;
            MainPage =  new AppShell();

            
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
