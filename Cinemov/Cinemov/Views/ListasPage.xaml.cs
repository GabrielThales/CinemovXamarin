using Cinemov.TMDB.Dto.Application.Models.FilmesDto;
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
    public partial class ListasPage : ContentPage
    {
        public static FilmeService Service;
        public ListasPage()
        {
            InitializeComponent();
            Service = new FilmeService();
            var sessionId = SecureStorage.GetAsync("session_id").Result;
            ListViewListaFilme.ItemSelected += ListViewListaFilme_ItemSelected;
        }

        private void ListViewListaFilme_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var filme = (FilmeDto) e.SelectedItem;

            Navigation.PushAsync(new FilmeDetails(filme));
        }

        private async void PickerListas_SelectedIndexChanged(object sender, EventArgs e)
        {
            var sessionId = await SecureStorage.GetAsync("session_id");
            switch (PickerListas.SelectedIndex)
            {

                case 0: ListViewListaFilme.ItemsSource = Service.GetFilmesFavoritos(sessionId, 1).Result.results;
                    break;

                case 1: ListViewListaFilme.ItemsSource = Service.GetWatchlist(sessionId, 1).Result.results;
                    break;

                case 2: ListViewListaFilme.ItemsSource = Service.GetFilmesAvaliados(sessionId, 1).Result.results;
                    break;
            }
        }
    }
}