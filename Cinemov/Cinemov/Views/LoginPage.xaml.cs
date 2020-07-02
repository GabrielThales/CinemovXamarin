using Cinemov.TMDB.Dto.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cinemov.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        private AuthenticationService Service;
        public LoginPage()
        {
            InitializeComponent();
            Service = new AuthenticationService();
        }

        protected override bool OnBackButtonPressed()
        {
            return false;
        }


        private async void ButtonLogin_Clicked(object sender, EventArgs e)
        {
             var token = await Service.GetToken();
            var session = await Service.CreateSession(EntryLogin.Text, EntrySenha.Text, token);

            if (session)
            {
                var sessionId = await Service.CreateSessionId(token);
                await SecureStorage.SetAsync("session_id", sessionId.session_id);
                //await DisplayAlert("Session Id", sessionId.session_id, "ok");
                await Navigation.PopModalAsync();
            } else
            {
                await DisplayAlert(":(", "Login ou senha Incorretos", "Tentar Novamente");
            }

        }

        private async void ButtonCriarConta_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Criar Conta TMDB", "Você será redirecionado para a pagina do The Movie Database, onde poderá criar uma conta para usar todos os recursos disponiveis no Cinemov, não esqueça de confirmar o cadastro no seu email", "Ok, Vamos lá");
            var uri = new Uri("https://www.themoviedb.org/account/signup");
            await Browser.OpenAsync(uri, new BrowserLaunchOptions
            {
                LaunchMode = BrowserLaunchMode.SystemPreferred,
                TitleMode = BrowserTitleMode.Show,
                PreferredToolbarColor = Color.AliceBlue,
                PreferredControlColor = Color.Violet
            });
        }
    }
}