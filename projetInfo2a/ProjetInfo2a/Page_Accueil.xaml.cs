using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjetInfo2a
{
    /// <summary>
    /// Logique d'interaction pour Accueil.xaml
    /// </summary>
    public partial class Page_Accueil : Page
    {
        public ClassMission _mission;

        public Page_Accueil()
        {
            InitializeComponent();

            _mission = ((MainWindow)System.Windows.Application.Current.MainWindow).getMission();
        }

        public Page_Accueil(ClassMission mission)
        {
            InitializeComponent();
            _mission = mission;
        }


        private void AfficherPlanning(object sender, RoutedEventArgs e)
        {
            Page_Planning planning = new Page_Planning();
            this.NavigationService.Navigate(planning);
        }

        private void AfficherExploration(object sender, RoutedEventArgs e)
        {
            Page_Exploration exploration = new Page_Exploration();
            this.NavigationService.Navigate(exploration);
        }

        private void AfficherRecherche(object sender, RoutedEventArgs e)
        {
            Page_Recherche recherche = new Page_Recherche();
            this.NavigationService.Navigate(recherche);
        }

    }
}
