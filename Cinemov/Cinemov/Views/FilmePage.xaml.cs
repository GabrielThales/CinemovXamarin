using Cinemov.Domain.Entities;
using Cinemov.TMDB.Dto.Application.Models.FilmesDto;
using Cinemov.TMDB.Dto.Application.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cinemov.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FilmePage : ContentPage
    {
        private static FilmeService Service = new FilmeService();
        FilmesCinemaDto FilmesEmCartaz = Service.GetFilmesEmCartaz().Result;
        public static ObservableCollection<Avaliacao> Avaliacoes;
        public FilmePage()
        {
            InitializeComponent();
            CarouselDiscoverFilmes.ItemsSource = FilmesEmCartaz.results;
            Avaliacoes = new ObservableCollection<Avaliacao>(App.AvaliacaoService.GetAllAvaliacoes());
            ListViewAvaliacoes.ItemsSource = Avaliacoes;
            ListViewAvaliacoes.ItemSelected += ListViewAvaliacoes_ItemSelected;

        }

        private void ListViewAvaliacoes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var avaliacao = (Avaliacao)e.SelectedItem;
            Navigation.PushAsync(new AvaliacaoPage(avaliacao));
        }

        private void ImageNovidadeButton_Clicked(object sender, EventArgs e)
        {
            var filme = (FilmeDto) CarouselDiscoverFilmes.CurrentItem;

            Navigation.PushAsync(new FilmeDetails(filme));
        }
    }
}