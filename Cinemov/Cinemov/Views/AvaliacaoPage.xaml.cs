using Cinemov.Domain.Entities;
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
    public partial class AvaliacaoPage : ContentPage
    {
        public Avaliacao Avaliacao;
        public AvaliacaoPage(Avaliacao avaliacao)
        {
            InitializeComponent();
            this.Avaliacao = avaliacao;
            PreencherCampos();
        }

        public void PreencherCampos()
        {
            LabelNomeFilme.Text = Avaliacao.FilmeTitulo;
            ImagePoster.Source = Avaliacao.Poster;
            LabelTitulo.Text = Avaliacao.Titulo;
            LabelMeuVoto.Text = Avaliacao.NotaFilme.ToString();
            LabelDescricao.Text = Avaliacao.Review;

        }
    }
}