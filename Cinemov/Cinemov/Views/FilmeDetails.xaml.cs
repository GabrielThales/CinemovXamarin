using Cinemov.TMDB.Dto.Application.Models.FilmesDto;
using Cinemov.TMDB.Dto.Application.Services;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cinemov.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FilmeDetails : ContentPage
    {
        private FilmeDetailDto FilmeDetailsObject;
        private FilmeService Service = new FilmeService();
        //private VideoService VideoService = new VideoService();
        private string Trailer;
        public FilmeDetails(FilmeDto Filme)
        {
            InitializeComponent();
            FilmeDetailsObject = Service.GetFilmeDetails(Filme.id).Result;
            PreencherCampos();

            if (FilmeDetailsObject.video)
            {
                //Trailer = VideoService.GetTrailer(FilmeDetailsObject.id).Result;
            }
        }

        private void PreencherCampos()
        {
            //this.BackgroundImageSource = "https://image.tmdb.org/t/p/original/" + FilmeDetailsObject.backdrop_path;
            ImagePoster.Source = FilmeDetailsObject.poster_path;
            LabelNomeFilme.Text = FilmeDetailsObject.title;
            LabelOverview.Text = FilmeDetailsObject.overview;
            LabelTagLine.Text = FilmeDetailsObject.tagline;
            LabelVoteAverage.Text = $"Média: {FilmeDetailsObject.vote_average}";
            LabelBudget.Text = $"Orçamento: $ {FilmeDetailsObject.budget}";
            LabelRuntime.Text = $"Duração: {FilmeDetailsObject.runtime} minutos";
            LabelReleaseDate.Text = $"Data de Lançamento: {FilmeDetailsObject.release_date}";
            LabelStatus.Text = $"Status: {FilmeDetailsObject.status}";
        }

        public async Task SpeakNowDefaultSettings(string texto)
        {
            var locales = await TextToSpeech.GetLocalesAsync();

            // Grab the first locale
            var locale = locales.FirstOrDefault(l => l.Language.Equals("pt-BR"));
            //var locale = locales;

            var settings = new SpeechOptions()
            {
                Volume = .75f,
                Pitch = 1.0f,
                Locale = locale
            };

            await TextToSpeech.SpeakAsync(texto, settings);

            // This method will block until utterance finishes.
        }

        private async void ImageButtonAddFavoritos_Clicked(object sender, System.EventArgs e)
        {
            var sessionId = await SecureStorage.GetAsync("session_id");
            var addfav = await Service.AddFilmeFavorito(FilmeDetailsObject.id, sessionId);

            if (addfav)
            {
                await DisplayAlert(":D", $"{FilmeDetailsObject.title} adicionado aos favoritos", "Ok");
            }
        }

        private async void ImageButtonAddWatchList_Clicked(object sender, System.EventArgs e)
        {
            var sessionId = await SecureStorage.GetAsync("session_id");
            var addWatchlist = await Service.AddWatchList(FilmeDetailsObject.id, sessionId);

            if (addWatchlist)
            {
                await DisplayAlert(":D", $"{FilmeDetailsObject.title} adicionado a watchlist", "Ok");
            }
        }

        private void ImageButtonAvaliacao_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new AddAvaliacao(FilmeDetailsObject));
        }

        private void ButtonOuvir_Clicked(object sender, System.EventArgs e)
        {
            SpeakNowDefaultSettings(LabelOverview.Text);
        }
    }
}