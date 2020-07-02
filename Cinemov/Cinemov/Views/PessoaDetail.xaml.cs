using Cinemov.TMDB.Dto.Application.Models.PesquisaDto;
using Cinemov.TMDB.Dto.Application.Models.PessoasDto;
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
    public partial class PessoaDetail : ContentPage
    {
        private PessoaDto Pessoa;
        private PessoaService Service;
        public PessoaDetail(PesquisaPessoaDto.Result Pessoa)
        {
            InitializeComponent();
            Service = new PessoaService();
            this.Pessoa = Service.GetPessoaDetails(Pessoa.id).Result;
            PreencherCampos();
        }

        public void PreencherCampos()
        {
            LabelNome.Text = Pessoa.name;
            ImagePoster.Source = Pessoa.profile_path;
            LabelLocalNascimento.Text = "Local de Nascimento: " + Pessoa.place_of_birth;
            LabelDataNascimento.Text = "Data nascimento: " + Pessoa.birthday;
            LabelOverview.Text = Pessoa.biography;
        }
    }
}