using Campeonato_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Campeonato_App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PrincipalView : ContentPage
    {
        public PrincipalView()
        {
            InitializeComponent();
            List<Jogo> jogos = new List<Jogo>();
            Jogo jogo = new Jogo();
            jogo.selecaoCasa = "Brasil";
            jogo.selecaoVisitante = "Argentina";
            jogo.placarCasa = 2;
            jogo.placarVisitante = 0;
            jogo.data = Convert.ToDateTime("01/07/2020");
            jogo.estadio = "Arena Fonte Nova";
            jogos.Add(jogo);

            jogosList.ItemsSource = jogos;
        }
    }
}