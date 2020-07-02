using Cinemov.TMDB.Dto.Application.Models.FilmesDto;
using Cinemov.TMDB.Dto.Application.Models.PesquisaDto;
using Cinemov.TMDB.Dto.Application.Models.PessoasDto;
using Cinemov.TMDB.Dto.Application.Models.SeriesDto;
using Cinemov.TMDB.Dto.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cinemov.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PesquisaPage : ContentPage
    {
        public PesquisaService pesquisa;
        public PesquisaPage()
        {
            InitializeComponent();
            pesquisa = new PesquisaService();
            ListViewFilme.ItemSelected += ListViewFilme_ItemSelected;
            ListViewSerie.ItemSelected += ListViewSerie_ItemSelected;
            ListViewPessoa.ItemSelected += ListViewPessoa_ItemSelected;
        }

        private void ListViewPessoa_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var pessoa = (PesquisaPessoaDto.Result)e.SelectedItem;
            Navigation.PushAsync(new PessoaDetail(pessoa));
        }

        private void ListViewSerie_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var serie = (SerieDto)e.SelectedItem;
            Navigation.PushAsync(new SerieDetails());
        }

        private void ListViewFilme_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var filme = (FilmeDto)e.SelectedItem;

            Navigation.PushAsync(new FilmeDetails(filme));
        }

        private void SearchBar_SearchButtonPressed(object sender, EventArgs e)
        {
            switch (PickerTipo.SelectedItem)
            {
                case "Filme": ListViewFilme.ItemsSource = pesquisa.GetPesquisaFilmes(SearchBarPesquisaFilme.Text).Result.results;
                    StackLayoutFilme.IsVisible = true;
                    StackLayoutPessoa.IsVisible = false;
                    StackLayoutSerie.IsVisible = false;
                    break;


                case "Série": ListViewSerie.ItemsSource = pesquisa.GetPesquisaSeries(SearchBarPesquisaFilme.Text).Result.results;
                    StackLayoutFilme.IsVisible = false;
                    StackLayoutPessoa.IsVisible = false;
                    StackLayoutSerie.IsVisible = true;
                    break;


                case "Pessoa": ListViewPessoa.ItemsSource = pesquisa.GetPesquisaPessoas(SearchBarPesquisaFilme.Text).Result.results;
                    StackLayoutFilme.IsVisible = false;
                    StackLayoutPessoa.IsVisible = true;
                    StackLayoutSerie.IsVisible = false;
                    break;

                default: DisplayAlert("Escolha o Tipo de Pesquisa", "Nenhum tipo de Pesquisa foi escolhido", "Ok");
                    break;
            }


        }
    }
}