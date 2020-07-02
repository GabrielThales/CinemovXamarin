using Cinemov.Domain.Entities;
using Cinemov.TMDB.Dto.Application.Models.FilmesDto;
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
    public partial class AddAvaliacao : ContentPage
    {
        public FilmeDetailDto Filme;
        public FilmeService Service;
        public AddAvaliacao(FilmeDetailDto filme)
        {
            InitializeComponent();
            Service = new FilmeService();
            this.Filme = filme;
            LabelNomeFilme.Text = filme.title;
            ImagePoster.Source = filme.poster_path;
        }

        private void ButtonAddAvaliacao_Clicked(object sender, EventArgs e)
        {
            var avaliacao = new Avaliacao(Filme.id, Filme.title, Filme.poster_path, EntryTitulo.Text, EntryDescricao.Text, float.Parse(EntryMeuVoto.Value.ToString()));
            //await Service.AvaliarFilme(Filme.id,App.SessionId, avaliacao.NotaFilme);
            App.AvaliacaoService.Create(avaliacao);
            FilmePage.Avaliacoes.Add(avaliacao);
            Navigation.PopModalAsync();
        }

        private void EntryMeuVoto_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            LabelNota.Text = $"Nota = {EntryMeuVoto.Value}";
        }
    }
}